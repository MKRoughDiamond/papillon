using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public int id;                  // Unique ID of item
    public string name;             // Name of item
    public string description;      // Item description
    public float weight;

    public delegate IEnumerator ItemEffect(Item item);
    public ItemEffect effect;       // Item effect

    private Texture2D icon;         // Item icon


    public Item(int id, string name, string description, float weight, ItemEffect effect) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.weight = weight;
        this.effect = effect;

        LoadIcon();
    }

    private void LoadIcon() {
        // TODO: icon load
    }


    public float getWeight() {
        return this.weight;
    }
}
