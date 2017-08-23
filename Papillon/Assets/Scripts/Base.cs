using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base 클래스
/// </summary>
public class Base {

    private GameManager gm;
    private CraftManager cm;
    private Player player;

    public List<InventoryElement> inventory;    // Items that base holds

    private int id;
    private List<CultivateElement> seedList;
    private List<CultivateElement> cultivatingList;
    private List<CultivateElement> doneList;

    // base upgrade level
    private int craftLevel = 1;
    private int cultivateLevel = 1;

    public Base(int id) {

        gm = GameManager.gm;
        cm = gm.getCraftManager();
        player = gm.getPlayer();

        this.id = id;
        cultivatingList = new List<CultivateElement>();
        doneList = new List<CultivateElement>();

        inventory = new List<InventoryElement>();
    }

    public int getId() {
        return id;
    }

    // called when entering base
    public void updateBaseStates(int day) {
        updateCultivateState(day);
    }

    #region Base Upgrade ralated

    // check base upgrade is possible
    // ( checks max level of upgrade, not meterial )
    public bool canUpgradeBase(int upgradeType) {
        if (upgradeType == BASEUPGRADE.CRAFT) {
            return BASEUPGRADE.CRAFT_UPGRADE.Length > craftLevel;
        } else if (upgradeType == BASEUPGRADE.CULTIVATE) {
            return BASEUPGRADE.CULTIVATE_UPGRADE.Length > cultivateLevel;
        } else {
            return false;
        }
    }

    // try upgrade base
    public void upgradeBase(int upgradeType) {
        if(upgradeType == BASEUPGRADE.CRAFT) {
            if (cm.craft(BASEUPGRADE.CRAFT_UPGRADE[craftLevel], 1)) {
                craftLevel++;
            }
        }
        else if(upgradeType == BASEUPGRADE.CULTIVATE) {
            if(cm.craft(BASEUPGRADE.CULTIVATE_UPGRADE[cultivateLevel], 1)) {
                cultivateLevel++;
            }
        }
    }
#endregion

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

    public List<InventoryElement> getInventory() {
        return inventory;
    }

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

    // remove item
    // used for crafting or discarding
    public bool removeItem(int id, int count) {
        for (int i = inventory.Count - 1; i >= 0; i--) {
            if (inventory[i].item.getId() == id) {

                if (inventory[i].count >= count) {
                    inventory[i].updateCount(-count);

                    if (inventory[i].count == 0)
                        inventory.RemoveAt(i);
                    return true;
                } else {
                    Debug.Log("ERROR : removeItem() fail - not enough items");
                    return false;
                }
            }
        }

        return false;
    }

    #endregion
}

public static class BASEUPGRADE {
    public const int CRAFT = 1;
    public const int CULTIVATE = 2;

    public static int[] CRAFT_UPGRADE =  new int[] { -1, 1002, 1003 };
    public static int[] CULTIVATE_UPGRADE = new int[] { -1, 1012, 1013 };
}
