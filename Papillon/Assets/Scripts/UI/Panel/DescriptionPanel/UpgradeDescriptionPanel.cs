using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDescriptionPanel : DescriptionPanel {

    public Text name;
    public Text description;

    public override void setDescriptee(GameObject descriptee) {

        int type = descriptee.GetComponent<UpgradeButton>().upgradeType;
        Base baseObject = GameManager.gm.getBoardManager().getBase();

        if(type == BASEUPGRADE.CRAFT) {
            int craftLevel = baseObject.getCraftLevel();
            name.text = "LV " + craftLevel.ToString();

            Recipe recipe = RecipeDatabase.findRecipe(BASEUPGRADE.CRAFT_UPGRADE[craftLevel]);
            string msg = "";

            List<RecipeElement> ingredients = recipe.getIngredients();
            foreach (RecipeElement e in ingredients) {
                msg += e.item.getName() + " x " + e.count.ToString() + "\n";
            }

            description.text = msg;

        } else if(type == BASEUPGRADE.CULTIVATE) {
            int cultivateLevel = baseObject.getCraftLevel();
            name.text = "LV " + cultivateLevel.ToString();

            Recipe recipe = RecipeDatabase.findRecipe(BASEUPGRADE.CULTIVATE_UPGRADE[cultivateLevel]);
            string msg = "";

            List<RecipeElement> ingredients = recipe.getIngredients();
            foreach (RecipeElement e in ingredients) {
                msg += e.item.getName() + " x " + e.count.ToString() + "\n";
            }

            description.text = msg;
        }
    }
}
