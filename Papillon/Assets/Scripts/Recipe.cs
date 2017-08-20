using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe {

    public int id;                              // recipe unique id
    public List<RecipeElement> ingredients;     // ingredients needed to generate product
    public RecipeElement product;               // product that will be generated
    public string requireTech;                  // if specific tech is required for crafting

    public Recipe(int id, List<RecipeElement> ingredients, RecipeElement product) {
        this.id = id;
        this.ingredients = new List<RecipeElement>(ingredients);
        this.product = product;
        this.requireTech = "";
    }

    public Recipe(int id, List<RecipeElement> ingredients, RecipeElement product, string requireTech) {
        this.id = id;
        this.ingredients = new List<RecipeElement>(ingredients);
        this.product = product;
        this.requireTech = requireTech;
    }

    public int getId() {
        return id;
    }

    public List<RecipeElement> getIngredients() {
        return ingredients;
    }

    public RecipeElement getProduct() {
        return product;
    }

    public string getRequireTech()
    {
        return requireTech;
    }
}

public class RecipeElement {

    public Item item;
    public int count;

    public RecipeElement(int id, int count) {
        // this.id = id;
        this.item = ItemDatabase.findItem(id);
        this.count = count;
    }
}
