using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDatabase : MonoBehaviour {

    private static List<Recipe> itemList;

    public static void init() {

        // NOT IMPLEMENTED

        // below is for test

        itemList = new List<Recipe>();
    }

    public static Recipe findRecipe(int id) {
        //TODO: implement
        //return found_recipe;
        return new Recipe(0, new List<RecipeElement>(), new RecipeElement(1, 1));
    }

    public static List<Recipe> load() {
        // TODO: implement
        return new List<Recipe>();
    }
}
