using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using UnityEngine;

public class RecipeDatabase : MonoBehaviour {

    private static List<Recipe> recipeList;

    public static void init(TextAsset reader) {
        recipeList = new List<Recipe>();

        try {
            string[] lines;
                
            lines = reader.text.Split('\n');
            foreach(string line in lines) {

                // for database comment
                if (line[0] == '#')
                    continue;

                string[] words = line.Split(' ');

                // RECIPE DB : 'ID ING1 NUM1 ING2 NUM2 ING3 NUM3 ... | PRODUCT_NUM'
                int section = Array.IndexOf(words, "|");
                List<RecipeElement> ingredients = new List<RecipeElement>();
                for (int i = 1; i < section; i += 2) {
                    ingredients.Add(new RecipeElement(int.Parse(words[i]), int.Parse(words[i+1])));
                }

                // if recipe can generate multiple product, code below need to be fixed.
                RecipeElement product = new RecipeElement(int.Parse(words[section+1]), int.Parse(words[section+2]));

                // ADDITIONAL RECIPE : '~ REQUIRED TECH'
                if(section+3 < words.Length) {
                    List<int> requiredTech = new List<int>();
                    for (int i = section + 4; !words[i].Equals("|"); i++)
                        requiredTech.Add(int.Parse(words[i]));
                    recipeList.Add(new Recipe(
                        int.Parse(words[0]),
                        ingredients,
                        product,
                        requiredTech,
                        int.Parse(words[words.Length - 1])
                        ));
                }
                else
                    recipeList.Add(new Recipe(
                        int.Parse(words[0]),
                        ingredients,
                        product
                        ));
            }
        } catch (System.Exception e) {
            Debug.Log("Wrong File " + e);
        }
    }

    public static Recipe findRecipe(int id) {
        foreach(Recipe recipe in recipeList) {
            if (recipe.getId() == id)
                return recipe;
        }
        return new Recipe(0, new List<RecipeElement>(), new RecipeElement(1, 1));
    }

    public static List<Recipe> load() {
        return recipeList;
    }
}