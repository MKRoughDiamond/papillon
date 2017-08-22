using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>
/// 이펙트와 관련한 모든 작업을 처리하는 클래스
/// </summary>
public class EffectProcessor {

    private GameManager gm;
    private BoardManager bm;
    private CraftManager cm;
    private ResearchManager rm;

    private Player player;

    public void init() {
        gm = GameManager.gm;
        bm = gm.getBoardManager();
        cm = gm.getCraftManager();
        rm = gm.getResearchManager();
        player = gm.getPlayer();
    }

    public bool process(Effect effect, bool flag = true) {
        if(effect is ItemEffect) {
            return itemEffectProcess((ItemEffect)effect,flag);
        }
        return false;
    }

    #region ItemEffect

    private string itemEffectPrefix = "ITEM_"; // tell function is related with item effect
    private string itemEffectPostfix = "_Reverse";

    public bool itemEffectProcess(ItemEffect effect, bool flag) {
        MethodInfo method;
        if (flag)
            method = this.GetType().GetMethod(itemEffectPrefix + effect.name);
        else
            method = this.GetType().GetMethod(itemEffectPrefix + effect.name + itemEffectPostfix);

        object[] parameters = new object[1];
        parameters[0] = effect.parameters;

        method.Invoke(this, parameters);
        return true;
    }

    // restore player health
    public void ITEM_Health_Restore(List<int> param) {
        int value = param[0];

        player.changeHealth(value);
    }

    // restore player satiety
    public void ITEM_Satiety_Restore(List<int> param) {
        int value = param[0];

        player.changeSatiety(value);
    }

    // get damage with probability
    public void ITEM_Damage_With_Prob(List<int> param) {
        int value = param[0];
        int prob = param[1];

        player.getDamageWithProb(value * (-1), prob);
    }

    public void ITEM_Protection(List<int> param) {
        int value = param[0];

        player.changeArmor(value);
    }

    public void ITEM_Protection_Reverse(List<int> param) {
        int value = param[0] * -1;

        player.changeArmor(value);
    }

    public void ITEM_Efficiency(List<int> param)
    {
        int value = param[0];

        //player.changeEfficiency(value);
    }

    public void ITEM_Efficiency_Reverse(List<int> param)
    {
        int value = param[0] * -1;

        //player.changeEfficiency(value);
    }

    // harvest from seed
    public void ITEM_Seed(List<int> param) {
        // int day = param[0];
        int productId = param[1];
        int productCount = param[2];
        int seedId = param[3];
        int seedCount = param[4];

        player.addItem(productId, productCount);
        player.addItem(seedId, seedCount);
    }

    #endregion

    //public bool process(FieldEffect effect) {
    //    return true;
    //}

    //public bool process(ResearchEffect effect) {
    //    return true;
    //}
}
