using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftPanelElement : MonoBehaviour {


    public Text name;       // name of product
    public Text ingredients;       // list of ingredients
    public Image icon;

    private CraftManager cm;
    private Recipe recipe;

    private void Start() {
        cm = GameManager.gm.getCraftManager();
    }

    public void init(Recipe recipe) {
        this.recipe = recipe;

        name.text = this.recipe.getProduct().item.getName();
        ingredients.text = generateIngredientsText(this.recipe.getIngredients());

        // icon = recipe.getProduct().getIcon(); 
    }

    private string generateIngredientsText(List<RecipeElement> ingredients) {
        string text = "";
        foreach (RecipeElement e in ingredients) {
            text += e.item.getName() + " x" + e.count.ToString() + "\n";
        }

        return text;
    }

    public void onClick() {
        cm.craft(this.recipe.getId(), 1);
    }
}
