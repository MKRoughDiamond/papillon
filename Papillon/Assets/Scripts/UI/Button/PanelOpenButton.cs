using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpenButton : MonoBehaviour {

    public GameObject panel;

    private Panel panelScript;

    private void Start() {
        panelScript = panel.GetComponent<Panel>();
    }

    public void onClick() {
        panelScript.open();
    }
}
