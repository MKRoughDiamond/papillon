using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int max_health;
    public int max_satiety;
    public int max_armor;
    public float max_weight;

    public int health;
    public int satiety;
    public int armor;
    public List<Item> items;                // Items that player holds
    public float ItemWeightsSum;            // Sum of item weights
    public bool ItemOverLoaded;             // ItemWeightsSum > max_weight ?

    public bool inBuff;                     // player is getting buff


    public Player(int max_health, int max_satiety, int max_armor, float max_weight) {
        this.max_health = max_health;
        this.max_satiety = max_satiety;
        this.max_armor = max_armor;
        this.max_weight = max_weight;

        initializeStates();
    }

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
        return ItemOverLoaded == true;
    }

    public bool isOnBuff() {
        return inBuff == true;
    }

    public bool useItem(int id) {
        foreach(Item item in items) {
            if(item.id == id && item.isUsable) {
                // TODO: try use item
                return true;
            }
        }

        return false;
    }

    private void updateItemWeightsSum() {
        float sum = 0.0f;
        foreach (Item item in items) {
            sum += item.getWeight();
        }

        ItemOverLoaded = sum > max_weight;
        ItemWeightsSum = sum;
    }



}
