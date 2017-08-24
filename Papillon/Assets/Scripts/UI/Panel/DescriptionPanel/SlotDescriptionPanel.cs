using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotDescriptionPanel : DescriptionPanel {
    
    public Text name;
    public Text description;

    private Slot slot;

    public override void setDescriptee(GameObject descriptee) {
        slot = descriptee.GetComponent<Slot>();
        name.text = slot.getName();
        description.text = slot.getDescription();
    }
}

// bad solution for sorting layer problem hahahaha
public class DescriptionPanel : MonoBehaviour {
    
    public virtual void setDescriptee(GameObject descriptee) {
        return;
    }
}