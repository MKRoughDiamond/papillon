using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Factory에서 crafting 관련 작업을 관리하는 매니저 클래스
/// </summary>
public class CraftManager : MonoBehaviour {

    private GameManager gm;
    private Player player;
    List<Recipe> recipeList;

    private void Awake() {
        gm = GameManager.gm;
        player = gm.getPlayer();
    }

    public void init() {
        recipeList = RecipeDatabase.load();
    }

    // craft Item
    public bool craft(int recipeId, int craftCount) {
        Recipe recipe = getRecipe(recipeId);
        List<RecipeElement> ingredients = recipe.getIngredients();
        RecipeElement product = recipe.getProduct();
        
        foreach(RecipeElement e in ingredients) {
            // player don't have enough item
            if(!player.checkItemPossession(e.item.getId(), e.count * craftCount)) {
                return false;
            }
        }
        
        foreach(RecipeElement e in ingredients) {
            player.removeItem(e.item.getId(), e.count * craftCount);
        }
        player.addItem(product.item.getId(), product.count);
        return true;
    }

    public List<Recipe> getRecipeList() {
        return recipeList;
    }

    private Recipe getRecipe(int id) {
        foreach(Recipe recipe in recipeList) {
            if(recipe.getId() == id) {
                return recipe;
            }
        }

        // if no matching recipe found
        return null;
    }
}
