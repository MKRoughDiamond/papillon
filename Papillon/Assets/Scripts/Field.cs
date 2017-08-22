using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field {

    private int type;
    // private effects
    private bool isBaseField;
    private int baseIdx;

    List<FieldItemElement> dropItemList;

    public Field(int type) {
        this.type = type;
        dropItemList = new List<FieldItemElement>();
        initItemList();
    }

    // initialize dropItemList
    private void initItemList() {
        List<FieldDropDatabaseElement> list = FieldDropDatabase.load(this.type);
        foreach (FieldDropDatabaseElement e in list) {
            int objectCount = Random.Range(e.minObjectCount, e.maxObjectCount+1);
            for (int i = 0; i < objectCount; i++) {
                int itemCount = Random.Range(e.minItemCount, e.maxItemCount+1);
                dropItemList.Add(new FieldItemElement(e.id, itemCount));
            }
        }
    }

    // set this field to base
    public bool setBase(int idx) {
        if (isBase()) {
            Debug.Log("ALREADY BASE");
            return false;
        }

        isBaseField = true;
        baseIdx = idx;
        // doSomeInitialize();
        return true;
    }

    public bool isBase() {
        return isBaseField;
    }

    public List<FieldItemElement> getItemList() {
        return dropItemList;
    }

    public void setItemList(List<FieldItemElement> itemList) {
        dropItemList = new List<FieldItemElement>(itemList);
    }

    public int getType() {
        return type;
    }

    public int getIndex() {
        return baseIdx;
    }
}

public static class FIELDTYPE {
    public const int FOREST = 0;
    public const int ICE = 1;
    public const int DESERT = 2;
}

public class FieldItemElement {
    public Item item;
    public int totalCount;
    public int currentCount;

    public FieldItemElement(int itemId, int count) {
        item = ItemDatabase.findItem(itemId);
        totalCount = count;
        currentCount = count;
    }

    public Item getItem() {
        return item;
    }
}