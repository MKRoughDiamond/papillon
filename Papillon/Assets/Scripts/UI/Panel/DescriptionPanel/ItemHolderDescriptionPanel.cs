using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHolderDescriptionPanel : DescriptionPanel {

    public Text name;
    public Text description;

    private ItemHolder holder;

    public override void setDescriptee(GameObject descriptee) {
        holder = descriptee.GetComponent<ItemHolder>();
        name.text = holder.possesion.getItem().getName();
        description.text = holder.possesion.getItem().getDescription();
    }
}
