using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftDescriptionPanel : DescriptionPanel {

    public Text description;

    private Recipe recipe;

    public override void setDescriptee(GameObject descriptee) {
        recipe = descriptee.GetComponent<CraftPanelElement>().getRecipe();
        description.text = recipe.getProduct().item.getDescription();
    }
}
