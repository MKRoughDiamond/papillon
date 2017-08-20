using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotDescriptionPanel : MonoBehaviour {
    
    public Text name;
    public Text description;

    private Slot slot;

    void Start() {
        slot = GetComponentInParent<Slot>();
        name.text = slot.getName();
        description.text = slot.getDescription();
    }
}
