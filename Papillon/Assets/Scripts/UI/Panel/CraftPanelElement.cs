using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftPanelElement : MonoBehaviour {


    public Text name;               // name of product
    public Text ingredients;       // list of ingredients
    public Image icon;             // icon of product

    private CraftManager cm;
    private Recipe recipe;

    private void Start() {
        cm = GameManager.gm.getCraftManager();
    }

    // initialize name, ingredients, icon
    public void init(Recipe recipe) {
        this.recipe = recipe;

        name.text = this.recipe.getProduct().item.getName() + " x" + this.recipe.getProduct().count.ToString();
        ingredients.text = generateIngredientsText(this.recipe.getIngredients());

        // icon = recipe.getProduct().getIcon(); 
    }

    // formalize text
    /*
     * 재료1 x n
     * 재료2 x m
     */
    private string generateIngredientsText(List<RecipeElement> ingredients) {
        string text = "";
        foreach (RecipeElement e in ingredients) {
            text += e.item.getName() + " x" + e.count.ToString() + "\n";
        }

        return text;
    }

    // when button is clicked, try craft
    public void onClick() {
        cm.craft(this.recipe.getId(), 1);
    }
}
