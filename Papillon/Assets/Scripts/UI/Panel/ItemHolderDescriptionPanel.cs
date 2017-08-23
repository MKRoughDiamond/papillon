using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHolderDescriptionPanel : MonoBehaviour {

    public Text name;
    public Text description;

    private ItemHolder holder;

    void Start() {
        holder = GetComponentInParent<ItemHolder>();
        name.text = holder.possesion.getItem().getName();
        description.text = holder.possesion.getItem().getDescription();
    }
}
