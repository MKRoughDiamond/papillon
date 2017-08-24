using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TechDescriptionPanel : DescriptionPanel {

    public Text description;

    private Technology tech;

    public override void setDescriptee(GameObject descriptee) {
        tech = descriptee.GetComponent<ResearchPanelElement>().getTech();
        description.text = tech.getDescription();
    }
}
