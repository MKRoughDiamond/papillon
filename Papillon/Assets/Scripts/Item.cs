using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

    private int id;                  // Unique ID of item
    private string name;             // Name of item
    private string description;      // Item description
    private float weight;            // Item weight
    private int armor;               // Item armor value
    private int type;           // Usable item

    public delegate IEnumerator ItemEffect(Item item);
    private ItemEffect effect;       // Item effect

    private Sprite icon;         // Item icon


    public Item(int id, string name, string description, float weight, int type, ItemEffect effect) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.weight = weight;
        this.effect = effect;
        this.type = type;

        LoadIcon();
    }

    public Item(int id, string name, string description, float weight, int type)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.weight = weight;
        this.type = type;
        effect = null;

        LoadIcon();
    }

    private void LoadIcon()
    {
        Sprite newIcon = Resources.Load<Sprite>("Icon/Item/" + name);
        if (newIcon)
            icon = newIcon;
        else
            Debug.Log("There is no item icon\t" + name);
    }

    public Sprite getIcon()
    {
        return icon;
    }

    public int getId() {
        return id;
    }

    public string getName() {
        return name;
    }

    public string getDescription() {
        return description;
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
