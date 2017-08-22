using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base 클래스
/// </summary>
public class Base {

    private GameManager gm;
    private Player player;

    public List<InventoryElement> inventory;    // Items that base holds

    private int id;
    private List<CultivateElement> seedList;
    private List<CultivateElement> cultivatingList;
    private List<CultivateElement> doneList;

    public Base(int id) {

        gm = GameManager.gm;
        player = gm.getPlayer();

        this.id = id;
        cultivatingList = new List<CultivateElement>();
        doneList = new List<CultivateElement>();
    }

    public int getId() {
        return id;
    }

    // called when entering base
    public void updateBaseStates(int day) {
        updateCultivateState(day);
    }

    #region Cultivation related

    // show all seeds that player have
    public List<CultivateElement> getSeedList(int day) {

        List<InventoryElement> inventory = player.getInventory();
        List<CultivateElement> seedList = new List<CultivateElement>();

        foreach (InventoryElement e in inventory) {
            if (e.item.getType() == ITEMTYPE.SEED) {
                seedList.Add(new CultivateElement(e.item, day));
            }
        }

        return seedList;
    }

    public List<CultivateElement> getCultivatingList() {
        return cultivatingList;
    }

    public List<CultivateElement> getDoneList() {
        return doneList;
    }

    // start cultivating
    public void cultivate(Item item, int day) {
        cultivatingList.Add(new CultivateElement(item, day));
        player.removeItem(item.getId(), 1);
    }

    // move finished cultivates to doneList
    public void updateCultivateState(int day) {
        for(int i = cultivatingList.Count-1; i >= 0; i--) {
            if (cultivatingList[i].isFinished(day)) {
                doneList.Add(cultivatingList[i]);
                cultivatingList.RemoveAt(i);
            }
        }
    }

    // harvest from doneList
    public void harvest(int id) {

        for(int i = doneList.Count-1; i >= 0; i--) {
            if(doneList[i].getItem().getId() == id) {
                gm.doEffect(doneList[i].getItem().getEffect());
                doneList.RemoveAt(i);
                return;
            }
        }
    }

    #endregion

    #region inventory related

    // add item to base inventory
    public void addItem(int id, int count) {

        if (count == 0)
            return;

        Item item = ItemDatabase.findItem(id);

        bool haveItem = checkItemPossession(id, 1);

        // if don't have that item, add new element to Inventory
        if (!haveItem)
            inventory.Add(new InventoryElement(item, 0));

        // update count
        for (int i = 0; i < inventory.Count; i++) {
            if (inventory[i].item.getId() == id) {
                inventory[i].updateCount(count);
            }
        }
    }

    // check if base have item with count
    // used for crafting, adding item
    public bool checkItemPossession(int id, int count) {

        // special case
        if (count == 0)
            return true;

        foreach (InventoryElement e in inventory) {
            if (e.item.getId() == id)
                return e.count >= count;
        }
        return false;
    }

    #endregion
}
