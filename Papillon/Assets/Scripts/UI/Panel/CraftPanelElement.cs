using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftPanelElement : MonoBehaviour {


    public Text name;               // name of product
    public Text ingredients;       // list of ingredients
    public Text requirements;
    public Image icon;             // icon of product

    private GameManager gm;
    private CraftManager cm;
    private ResearchManager rm;
    private Player player;
    private Recipe recipe;

    private CraftPanel panel;

    //private void Awake() {
    //    gm = GameManager.gm;
    //    cm = gm.getCraftManager();
    //    player = gm.getPlayer();
    //}

    // initialize name, ingredients, icon
    public void init(Recipe recipe) {

        panel = GetComponentInParent<CraftPanel>();
        gm = GameManager.gm;
        cm = gm.getCraftManager();
        rm = gm.getResearchManager();
        player = gm.getPlayer();

        this.recipe = recipe;
        
        name.text = this.recipe.getProduct().item.getName() + " x " + this.recipe.getProduct().count.ToString();
        ingredients.text = generateIngredientsText(this.recipe.getIngredients());
        requirements.text = generateRequirementsText(this.recipe);

        icon.sprite = recipe.getProduct().item.getIcon(); 
    }

    public Recipe getRecipe() {
        return recipe;
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

            // highlight items player don't have
            if (!player.checkItemPossession(e.item.getId(), e.count)) {
                text += highlight(e.item.getName() + " x " + e.count.ToString());
            } else {
                text += e.item.getName() + " x " + e.count.ToString();
            }
        }
        return text;
    }

    private string generateRequirementsText(Recipe recipe) {
        List<int> requirements = recipe.getRequireTech();

        string text = "";
        bool flag = false;
        foreach (int id in requirements) {

            if (flag) text += "\n";
            else flag = true;

            if (rm.checkTechDone(id)) {
                text += TechnologyDatabase.findNameById(id);
            } else {
                text += highlight(TechnologyDatabase.findNameById(id));
            }
            
        }

        return text;
    }

    private string  highlight(string s, string color="red") {
        return "<color=" + color + ">" + s + "</color>";
    }

    // when button is clicked, try craft
    public void onClick() {
        if (cm.craft(this.recipe.getId(), 1)) {
            gm.playSE("wood-hammering");
            panel.makeCraftList();
        } else {
            gm.playSE("fail2");
        }
    }
}
