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
    
    // construct craft list that will be shown on the panel
    private void makeCraftList() {
        List<Recipe> recipeList = cm.getRecipeList();

        foreach(Recipe recipe in recipeList) {
            // Generate elements
            GameObject element = Instantiate(panelElement);
            element.GetComponent<CraftPanelElement>().init(recipe);

            // Attach it to panel scroll list
            // If you change name of object in inspector, you must change below code
            element.transform.parent = transform.Find("Scroll/Viewport/CraftList");
        }
    }


}