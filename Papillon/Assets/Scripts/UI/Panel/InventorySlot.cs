using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour{

    public Image icon;
    public Text count;
    
    private GameManager gm;
    private Player player;
    //private GameObject inventory;
    private Inventory inventoryScript;
    private InventoryElement element;

    private string name;
    private string description;

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

    public string getName() {
        return name;
    }

    public string getDescription() {
        return description;
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
