using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftPanel : Panel {

    private GameManager gm;
    private Player player;
    private CraftManager cm;

    private void Start() {
        gm = GameManager.gm;
        player = gm.getPlayer();
        cm = gm.getCraftManager();

        makeCraftList();

        gameObject.SetActive(false);
    }

    private void makeCraftList() {
        List<Recipe> recipeList = cm.getRecipeList();

        foreach(Recipe recipe in recipeList) {
            GameObject element = Instantiate(panelElement, transform.Find("Scroll View/ViewPort/CraftList"));
            element.GetComponent<CraftPanelElement>().init(recipe);
        }
    }


}