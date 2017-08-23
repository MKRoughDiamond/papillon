using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftPanel : Panel {

    private GameManager gm;
    private Player player;
    private CraftManager cm;
    private BoardManager bm;
    private ResearchManager rm;

    private void Start() {
        gm = GameManager.gm;
        player = gm.getPlayer();
        cm = gm.getCraftManager();
        bm = gm.getBoardManager();
        rm = gm.getResearchManager();

        makeCraftList();

        gameObject.SetActive(false);
    }
    
    // construct craft list that will be shown on the panel
    private void makeCraftList() {
        List<Recipe> recipeList = cm.getRecipeList();

        foreach(Recipe recipe in recipeList) {
            if (recipe.getId() >= 1000)
                continue;
            else {
                bool canCraft = true;
                
                //is all tech done
                if(recipe.getRequireTech() != null) { 
                    foreach (int tech in recipe.getRequireTech()) {
                        if(!rm.checkTechDone(tech)) {
                            canCraft = false;
                            break;
                        }
                    }
                }

                //is base crafting level sufficient
                if (bm.getBase().getCraftLevel() < recipe.getCraftLevel())
                    canCraft = false;

                if (!canCraft)
                    continue;
            }
            // Generate elements
            GameObject element = Instantiate(panelElement);
            element.GetComponent<CraftPanelElement>().init(recipe);
            // element.transform.Find("CraftIcon").GetComponent<Image>().sprite = element.GetComponent<CraftPanelElement>().icon;

            // Attach it to panel scroll list
            // If you change name of object in inspector, you must change below code
            element.transform.parent = transform.Find("Scroll/Viewport/CraftList");
        }
    }


}