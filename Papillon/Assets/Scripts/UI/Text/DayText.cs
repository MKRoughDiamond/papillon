using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DayText : MonoBehaviour {

    private GameManager gm;

    public Text dayText;

    private void Start() {
        gm = GameManager.gm;
    }

    private void Update() {
        int day = gm.getDay();
        dayText.text = day.ToString();
    }
}
