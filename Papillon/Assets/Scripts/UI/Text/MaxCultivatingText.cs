using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxCultivatingText : MonoBehaviour {

    public Text maxCultivatingText;

    private Base baseObject;

    private void Start() {
        baseObject = GameManager.gm.getBoardManager().getBase(); 
    }

    private void Update() {

        int curCount = baseObject.getCultivatingList().Count;
        int maxCount = baseObject.getMaxCultivateCount();

        if(curCount == maxCount) {
            maxCultivatingText.text = highlight("(" + curCount + "/" + maxCount + ")");
        } else {
            maxCultivatingText.text = "(" + curCount + "/" + maxCount + ")";
        }
    }

    private string highlight(string s, string color="red") {
        return "<color=" + color + ">" + s + "</color>";
    }
}
