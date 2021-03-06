﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultivateElement {

    private Item item;
    private int startDay;

    public CultivateElement(Item item, int startDay) {

        if(item.getType() != ITEMTYPE.SEED) {
            Debug.Log("ERROR : CULTIVATING ITEM IS NOT SEED");
        }

        this.item = item;
        this.startDay = startDay;
    }

    // get how many days are left
    public int getLeftDay(int day) {
        ItemEffect e = item.getEffect();

        if (e.name != "Seed") {
            Debug.Log("ERROR : CULTIVATING ITEM IS NOT SEED");
        }

        int requiredDay = e.parameters[0];
        int passedDay = day - startDay;

        return requiredDay - passedDay;
    }

    public int getProductId() {
        ItemEffect e = item.getEffect();

        if (e.name != "Seed") {
            Debug.Log("ERROR : ITEM IS NOT SEED");
        }

        int product = e.parameters[1];

        return product;
    }

    // check cultivating is done
    public bool isFinished(int day) {
        return getLeftDay(day) <= 0;
    }

    public Item getItem() {
        return item;
    }

    public int getStartDay() {
        return startDay;
    }

    public int getRequiredDay() {
        return item.getEffect().parameters[0];
    }
}
