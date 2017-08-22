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

    public bool process(Effect effect) {
        if(effect is ItemEffect) {
            return itemEffectProcess((ItemEffect)effect);
        }
        return false;
    }

    #region ItemEffect

    private string itemEffectPrefix = "ITEM_"; // tell function is related with item effect

    public bool itemEffectProcess(ItemEffect effect) {

        MethodInfo method = this.GetType().GetMethod(itemEffectPrefix + effect.name);

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

    #endregion

    //public bool process(FieldEffect effect) {
    //    return true;
    //}

    //public bool process(ResearchEffect effect) {
    //    return true;
    //}
}
