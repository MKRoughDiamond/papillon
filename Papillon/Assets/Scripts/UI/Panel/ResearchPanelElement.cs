﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchPanelElement : MonoBehaviour {

    public Text name;
    //public Text description;
    public Text requirements;
    public Text point;
    public Image icon;

    private ResearchPanel panel;
    private ResearchManager rm;
    private Technology tech;

    private void Start() {
        panel = GetComponentInParent<ResearchPanel>();
        rm = GameManager.gm.getResearchManager();
    }

    // initialize name, description, icon
    public void init(Technology tech) {
        this.tech = tech;

        name.text = this.tech.getName();
        //description.text = this.tech.getDescription();
        requirements.text = generateRequirementsText(this.tech.requirements);
        point.text = this.tech.getCurrentPoint().ToString() + '/' + this.tech.getResearchPoint().ToString();
        // icon = this.tech.getIcon();
    }

    // formalize text
    /*
     * 기술1
     * 기술2
     */
    private string generateRequirementsText(List<Requirement> requirements) {
        string text = "";
        foreach (Requirement e in requirements) {
            text += e.tech.getName() + "\n";
        }

        return text;
    }

    public void onClick() {
        // 나중에 유동값으로 바꾸자
        if(panel.getState() == "AVAILABLE") {
            rm.progress(tech.id, 10);
            panel.makeResearchList();
        }
    }
}