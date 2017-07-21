using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public int id;                  // Unique ID of item
    public string name;             // Name of item
    public string description;      // Item description
    public float weight;            // Item weight
    public int armor;               // Item armor value
    public int type;           // Usable item

    public delegate IEnumerator ItemEffect(Item item);
    public ItemEffect effect;       // Item effect

    private Texture2D icon;         // Item icon


    public Item(int id, string name, string description, float weight, int type, ItemEffect effect) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.weight = weight;
        this.effect = effect;
        this.type = type;

        LoadIcon();
    }

    public Item(int id, string name, string description, float weight, int type, int armor) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.weight = weight;

        this.type = type;

        LoadIcon();
    }

    private void LoadIcon() {
        // TODO: icon load
    }


    public float getWeight() {
        return weight;
    }

    public int getArmor() {
        if(type != ITEMTYPE.WEARABLE) {
            return 0;
        }
        return armor;
    }

    public float getType() {
        return type;
    }
}

public static class ITEMTYPE {
    public const int MATERIAL = 0;
    public const int USABLE = 1;
    public const int WEARABLE = 2;
}
