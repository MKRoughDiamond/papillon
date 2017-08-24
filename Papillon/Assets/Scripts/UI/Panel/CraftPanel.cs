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

    private string elementParent = "Scroll/Viewport/CraftList";

    private void Awake() {
        gm = GameManager.gm;
        player = gm.getPlayer();
        cm = gm.getCraftManager();
        bm = gm.getBoardManager();
        rm = gm.getResearchManager();

        makeCraftList();

        gameObject.SetActive(false);
    }
    
    // construct craft list that will be shown on the panel
    public void makeCraftList() {

        clearList();

        List<Recipe> recipeList = cm.getRecipeList();

        foreach(Recipe recipe in recipeList) {

            bool canCraft = true;

            // don't display upgrades
            if (recipe.getId() >= 1000)
                continue;

            else {
                
                // lets not use this 

                ////is all tech done
                //if(recipe.getRequireTech() != null) { 
                //    foreach (int tech in recipe.getRequireTech()) {
                //        if(!rm.checkTechDone(tech)) {
                //            canCraft = false;
                //            break;
                //        }
                //    }
                //}

                //is base crafting level sufficient
                if (bm.getBase().getCraftLevel() < recipe.getCraftLevel())
                    canCraft = false;

                //if (!canCraft)
                //    continue;
            }
            // Generate elements
            GameObject element = Instantiate(panelElement);

            // Attach it to panel scroll list
            // If you change name of object in inspector, you must change below code
            element.transform.parent = transform.Find(elementParent);

            element.GetComponent<CraftPanelElement>().init(recipe);

            // if craft level is not matched, set button not interactable
            if (!canCraft)
                element.GetComponent<Button>().interactable = false;
            // element.transform.Find("CraftIcon").GetComponent<Image>().sprite = element.GetComponent<CraftPanelElement>().icon;


        }
    }

    private void clearList() {
        Transform parent = transform.Find(elementParent);
        foreach(Transform t in parent) {
            Destroy(t.gameObject);
        }
    }

    private void OnEnable() {
        makeCraftList();
    }


}