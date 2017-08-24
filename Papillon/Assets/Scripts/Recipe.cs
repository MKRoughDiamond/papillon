using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe {

    public int id;                              // recipe unique id
    public List<RecipeElement> ingredients;     // ingredients needed to generate product
    public RecipeElement product;               // product that will be generated
    public List<int> requireTech;                  // if specific tech is required for crafting
    public int craftLevel;

    public Recipe(int id, List<RecipeElement> ingredients, RecipeElement product) {
        this.id = id;
        this.ingredients = new List<RecipeElement>(ingredients);
        this.product = product;
        this.requireTech = new List<int>();
        this.craftLevel = 1;
    }

    public Recipe(int id, List<RecipeElement> ingredients, RecipeElement product, List<int> requireTech, int craftLevel) {
        this.id = id;
        this.ingredients = new List<RecipeElement>(ingredients);
        this.product = product;
        this.requireTech = requireTech;
        this.craftLevel = craftLevel;
    }

    public int getId() {
        return id;
    }

    public int getCraftLevel() {
        return craftLevel;
    }

    public List<RecipeElement> getIngredients() {
        return ingredients;
    }

    public RecipeElement getProduct() {
        return product;
    }

    public List<int> getRequireTech()
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
