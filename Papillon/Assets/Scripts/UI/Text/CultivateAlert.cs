using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CultivateAlert : MonoBehaviour {

    private BoardManager bm;
    private Base baseObject;

    void Awake() {
        bm = GameManager.gm.getBoardManager();
        baseObject = bm.getBase();
    }
	
	// Update is called once per frame
	void Update () {
        if(baseObject.getDoneList().Count > 0) {
            gameObject.GetComponent<Image>().color = Color.white;
        } else {
            gameObject.GetComponent<Image>().color = Color.clear;
        }
	}
}
