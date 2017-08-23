using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBaseButton : MonoBehaviour {
    GameManager gm;
    CraftManager cm;
    Map map;

    private void Start() {
        gm = GameManager.gm;
        cm = gm.getCraftManager();
        map = gm.getBoardManager().getMap();
    }

    public void onClick() {
        if (cm.craft(1000, 1)) {
            gm.playSE("hammering");
            map.setBase();
        } else {
            Recipe recipe = RecipeDatabase.findRecipe(1000);
            string msg = "";

            msg += "다음의 재료가 필요합니다. \n\n";

            List<RecipeElement> ingredients = recipe.getIngredients();
            foreach (RecipeElement e in ingredients) {
                msg += e.item.getName() + " x " + e.count.ToString() + "\n";
            }

            gm.showMessage(msg);
        }
    }
}
