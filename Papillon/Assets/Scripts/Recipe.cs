using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour {

    public int id;                              // recipe unique id
    public List<RecipeElement> ingredients;     // ingredients needed to generate product
    public RecipeElement product;               // product that will be generated

    public Recipe(int id, List<RecipeElement> ingredients, RecipeElement product) {
        this.id = id;
        this.ingredients = new List<RecipeElement>(ingredients);
        this.product = product;
    }

    public List<RecipeElement> getIngredients() {
        return ingredients;
    }

    public RecipeElement getProduct() {
        return product;
    }
}

public class RecipeElement {

    public int id;
    public int count;

    public RecipeElement(int id, int count) {
        this.id = id;
        this.count = count;
    }
}
