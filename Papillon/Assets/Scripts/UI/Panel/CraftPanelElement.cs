using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftPanelElement : MonoBehaviour {


    public Text name;               // name of product
    public Text ingredients;       // list of ingredients
    public Image icon;             // icon of product

    private GameManager gm;
    private CraftManager cm;
    private Recipe recipe;

    private void Start() {
        gm = GameManager.gm;
        cm = gm.getCraftManager();
    }

    // initialize name, ingredients, icon
    public void init(Recipe recipe) {
        this.recipe = recipe;

        name.text = this.recipe.getProduct().item.getName() + " x" + this.recipe.getProduct().count.ToString();
        ingredients.text = generateIngredientsText(this.recipe.getIngredients());

        icon.sprite = recipe.getProduct().item.getIcon(); 
    }

    // formalize text
    /*
     * 재료1 x n
     * 재료2 x m
     */
    private string generateIngredientsText(List<RecipeElement> ingredients) {
        string text = "";
        bool flag = false;
        foreach (RecipeElement e in ingredients) {
            if (flag) text += "\n";
            else flag = true;
            text += e.item.getName() + " x " + e.count.ToString();
        }
        return text;
    }

    // when button is clicked, try craft
    public void onClick() {
        if (cm.craft(this.recipe.getId(), 1)) {
            gm.playSE("wood-hammering");
        } else {
            gm.playSE("fail2");
        }
    }
}
