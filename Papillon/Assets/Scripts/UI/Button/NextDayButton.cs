using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDayButton : MonoBehaviour {

    GameManager gm;

    private void Start() {
        gm = GameManager.gm;
    }

    public void onClick() {
        gm.goNextDay();
    }
}
