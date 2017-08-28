using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour {

    public GameObject[] images;
    public GameObject[] panels;

    public GameObject endPanel;

    bool start = false;

    int imageIndex = 0;
    int panelIndex = 0;
    bool[] imageSwitch = new bool[] {
        false, false, false, true,
        false,false,true,false,
        false,true,true,true,
        true,false,true,false,
        true,true,true,false,
        true,true,false,false,
        false,false,false,false,
        true,false,false,false,
        false,true,true,false,
        true,false,true,false,
        false, false,
    };

    public void onClick() {

        if (start) {

            Debug.Log("clicked");

            if (panelIndex >= panels.Length) {
                endTutorial();
            }

            if (panelIndex >= 1)
                panels[panelIndex-1].SetActive(false);

            panels[panelIndex].SetActive(true);

            if (imageSwitch[panelIndex]) {
                images[imageIndex++].SetActive(true);
            }

            panelIndex++;
        }
    }

    public void startTutorial() {
        start = true;
        GameObject.Find("StartPanel").SetActive(false);

        panels[panelIndex++].SetActive(true);
    }

    public void endTutorial() {
        start = false;

        foreach(GameObject e in images) {
            e.SetActive(false);
        }

        foreach(GameObject e in panels) {
            e.SetActive(false);
        }

        endPanel.SetActive(true);
    }
}
