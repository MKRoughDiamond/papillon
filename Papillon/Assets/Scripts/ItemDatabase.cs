using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    public static Item findItem(int id) {
        //TODO: implement
        //return found_item;
        return new Item(0, "Not", "Implemented", 0.0f, ITEMTYPE.MATERIAL, null);
    }
}
