using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeeperSlot : Slot {

    private GameManager gm;
    private Player player;
    private Base baseObject;

    private KeeperPanel keeperPanel;
    private List<InventoryElement> playerInventory;
    private List<InventoryElement> baseInventory;
    private InventoryElement element;

    private int type;

    public void init(InventoryElement e, int type) {
        this.type = type;
        element = e;

        gm = GameManager.gm;
        player = gm.getPlayer();
        baseObject = gm.getBoardManager().getBase();
        playerInventory = player.getInventory();
        baseInventory = baseObject.getInventory();
        keeperPanel = GetComponentInParent<KeeperPanel>();

        count.text = e.count.ToString();
        name = e.item.getName();
        description = e.item.getDescription();

        icon.sprite = e.item.getIcon();
    }

    public void onClick() {
        // move player item to base
        if(type == KEEPERSLOTTYPE.PLAYER) {
            baseObject.addItem(element.item.getId(), 1);
            player.removeItem(element.item.getId(), 1);   
        }
        // move base item to player (if possible)
        else if(type == KEEPERSLOTTYPE.BASE) {

            if(!player.addItem(element.item.getId(), 1)) {
                Debug.Log("KEEPER MOVE FAIL : PLAYER OVERLOADED!");
                return;
            }

            baseObject.removeItem(element.item.getId(), 1);
        }

        gm.playSE("move-item");
        keeperPanel.updateInventory();
    }
}

public static class KEEPERSLOTTYPE {
    public const int PLAYER = 1;
    public const int BASE = 2;
}