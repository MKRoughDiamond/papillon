using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base 클래스
/// </summary>
public class Base : MonoBehaviour {

    private GameManager gm;
    private Player player;

    public List<InventoryElement> inventory;    // Items that base holds

    private int idx;
    private List<CultivateElement> seedList;
    private List<CultivateElement> cultivatingList;
    private List<CultivateElement> doneList;

    public Base(int idx) {

        gm = GameManager.gm;
        player = gm.getPlayer();

        this.idx = idx;
        cultivatingList = new List<CultivateElement>();
        doneList = new List<CultivateElement>();
    }

    #region Cultivation related

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
        for(int i = 0; i < cultivatingList.Count; i++) {
            if (cultivatingList[i].isFinished(day)) {
                doneList.Add(cultivatingList[i]);
                cultivatingList.RemoveAt(i);
            }
        }
    }

    // harvest from doneList
    public void harvest(int idx) {
        gm.doEffect(doneList[idx].getItem().getEffect());
        doneList.RemoveAt(idx);
    }

    #endregion

    #region inventory related

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
