using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    private GameManager gm;

    private void Awake() {
        gm = GameManager.gm;
    }

    public void boardSetup(int scene) {
        switch (scene) {
            case SCENES.RESEARCH:
                researchSetup();
                break;
        }
    }

    private void researchSetup() {
        return;
    }
}
