using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftButton : MonoBehaviour {

    private int recipeId;
    private CraftManager cm;

    public CraftButton(int id) {
        recipeId = id;
        cm = GameManager.gm.getCraftManager();
    }

    public void onClick() {
        cm.craft(recipeId, 1);
    }
}
