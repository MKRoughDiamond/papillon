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

    public ItemEffect effect;           // item effect

    private Sprite icon;         // Item icon


    public Item(int id, string name, string description, float weight, int type, ItemEffect effect) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.weight = weight;
        this.effect = effect;
        this.type = type;
        if (effect.name == "Protection")
            this.armor = effect.parameters[0];
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
        Sprite notFound = Resources.Load<Sprite>("Icon/Item/not found");

        if (newIcon)
            icon = newIcon;
        else {
            Debug.Log("There is no item icon\t" + name);
            icon = notFound;
        }
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

    public ItemEffect getEffect() {
        return effect;
    }

    public int getType() {
        return type;
    }
}

public static class ITEMTYPE {
    public const int MATERIAL = 0;
    public const int USABLE = 1;
    public const int WEARABLE = 2;
}

public class ItemEffect : Effect {

    public List<int> parameters;

    public ItemEffect(string name, List<int> parameters) {
        this.name = name;
        this.parameters = new List<int>(parameters);
    } 
}