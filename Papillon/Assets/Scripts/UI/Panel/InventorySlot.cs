using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : Slot{
    
    private GameManager gm;
    private Player player;
    //private GameObject inventory;
    private Inventory inventoryScript;
    private InventoryElement element;

    public void init(InventoryElement e) {

        gm = GameManager.gm;
        player = gm.getPlayer();
        element = e;
        //inventory = gm.getInventory();
        inventoryScript = GetComponentInParent<Inventory>();

        count.text = e.count.ToString();
        name = e.item.getName();
        description = e.item.getDescription();

        icon.sprite = e.item.getIcon();
    }

    public void onClick() {
        bool success = player.useItem(element.item.getId());

        if (success) {
            inventoryScript.updateInventory();
            return;
        }

        return;
    }
}
