using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    public int max_health;
    public int max_satiety;
    public int max_armor;
    public float max_weight;

    public int health;
    public int satiety;
    public int armor;
    public List<InventoryElement> inventory;    // Items that player holds
    public float itemWeightsSum;                // Sum of item weights
    public bool itemOverLoaded;                 // ItemWeightsSum > max_weight ?

    //public bool inBuff;                     // player is getting buff

    public Player(int max_health, int max_satiety, int max_armor, float max_weight) {
        this.max_health = max_health;
        this.max_satiety = max_satiety;
        this.max_armor = max_armor;
        this.max_weight = max_weight;
        inventory = new List<InventoryElement>();
        initializeStates();
    }

    // initialize player's states
    private void initializeStates() {
        health = max_health;
        satiety = max_satiety;
        armor = max_armor;
        updateItemWeightsSum();
    }

    public void changeHealth(int d) {
        health = Mathf.Min(max_health, health + d);
    }

    public void changeSatiety(int d) {
        satiety = Mathf.Min(max_satiety, satiety + d);
    }

    public void changeArmor(int d) {
        armor = Mathf.Min(max_armor, armor + d);
    }

    public bool isOverLoaded() {
        return itemOverLoaded == true;
    }

    public int getHealth() {
        return health;
    }

    public int getMaxHealth() {
        return max_health;
    }
    
    public int getSatiety() {
        return satiety;
    }

    public int getMaxSatiety() {
        return max_satiety;
    }

    public int getArmor() {
        return armor;
    }

    public int getMaxArmor() {
        return max_armor;
    }

    public float getItemWeight() {
        return itemWeightsSum;
    }

    public float getMaxItemWeight() {
        return max_weight;
    }

    //public bool isOnBuff() {
    //    return inBuff == true;
    //}

    // get item from object(itemholder)
    public void addItem(int id, int count) {
        Item item = ItemDatabase.findItem(id);
        bool haveItem = checkItemPossession(id, 1);

        // if don't have that item, add new element to Inventory
        if (!haveItem)
            inventory.Add(new InventoryElement(item, 0));

        // update count
        for(int i = 0; i < inventory.Count; i++) {
            if(inventory[i].item.getId() == id) {
                inventory[i].updateCount(count);

                if(item.getType() == ITEMTYPE.WEARABLE) {
                    changeArmor(item.getArmor());
                }
            }
        }
        updateItemWeightsSum();

        // FOR DEBUG
        printInventory();
    }

    // use item
    public bool useItem(int id) {
        for (int i = inventory.Count - 1; i >= 0; i--) {
            if (inventory[i].item.getId() == id && inventory[i].item.getType() == ITEMTYPE.USABLE) {

                // doSomeEffect(item)
                inventory[i].count--;
  
                if(inventory[i].count == 0) {
                    inventory.RemoveAt(i);
                }

                Debug.Log("USED ITEM");
                return true;
            }
        }

        Debug.Log("NOT USABLE ITEM");
        return false;
    }

    // remove item
    // used for crafting or discarding
    public bool removeItem(int id, int count) {
        for (int i = inventory.Count - 1; i >= 0; i--) {
            if (inventory[i].item.getId() == id) {

                if(inventory[i].count > count) {
                    inventory[i].updateCount(-count);
                    return true;
                } else if(inventory[i].count == count) {
                    inventory[i].updateCount(-count);
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

    // check if player have item with enough count
    // used for crafting, adding item
    public bool checkItemPossession(int id, int count) {

        // special case
        if(count == 0)
            return true;

        foreach (InventoryElement e in inventory) {
            if (e.item.getId() == id)
                return e.count >= count;
        }
        return false;
    }

    // update total weight player holds, need to be called whenever player use or get item
    private void updateItemWeightsSum() {
        float sum = 0.0f;
        foreach (InventoryElement e in inventory) {
            sum += e.item.getWeight() * e.count;
        }

        itemOverLoaded = sum > max_weight;
        itemWeightsSum = sum;
    }

    // 디버그용 함수, 인벤토리 관련 GUI가 완성되면 고쳐서 사용하던가 폐기하기.
    private void printInventory() {
        Debug.Log("---Player inventory---");
        foreach(InventoryElement e in inventory) {
            Debug.Log(e.item.getName() + '/' + e.count.ToString());
        }
    }

    public List<InventoryElement> getInventory() {
        return inventory;
    }
}

public class InventoryElement {
    public Item item;
    public int count;

    public InventoryElement(Item item, int count) {
        this.item = item;
        this.count = count;
    }

    public void updateCount(int delta) {
        count += delta;
    }
}

