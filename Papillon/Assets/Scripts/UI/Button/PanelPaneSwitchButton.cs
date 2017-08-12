using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPaneSwitchButton : MonoBehaviour {

    public GameObject panel;
    public string paneName;

    private Panel panelScript;

    private void Start() {
        panelScript = panel.GetComponent<Panel>();
    }

    public void onClick() {
        panelScript.switchPane(paneName);
    }
}
