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
            int objectCount = Mathf.Max(0,Random.Range(e.minObjectCount, e.maxObjectCount+1));
            for (int i = 0; i < objectCount; i++) {
                int itemCount = Mathf.Max(0,Random.Range(e.minItemCount, e.maxItemCount+1));
                dropItemList.Add(new FieldItemElement(e.id, itemCount));
            }
        }

        // YES THIS IS FUCKING HARD-CODING!!
        /*
         * rocket 필드에는 우주선 구성에 필요한 5개 아이템이 있는데 (count가 0이라 필드 상에 표시되지는 않음)
         * 그 중 랜덤한 하나의 count를 -1로 지정해주고, 이것이 부족한 아이템이 된다
         */
        if(getType() == FIELDTYPE.ROCKET) {
            int randomIdx = Random.Range(0, dropItemList.Count);
            dropItemList[randomIdx].currentCount = -1;
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
    public const int RESIDENTIAL = 1;
    public const int FACTORY = 2;

    public const int ROCKET = 11; // APOLLO!!!!!!

    public static int[] TYPES = new int[] {
        FOREST,
        FOREST,
        FOREST,
        RESIDENTIAL,
        RESIDENTIAL,
        RESIDENTIAL,
        FACTORY,
        FACTORY,
        FACTORY,
        ROCKET
    };
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