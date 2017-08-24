using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class ExploreAlert : MonoBehaviour {

    GameManager gm;
    Image alertImage;

	void Start () {
        gm = GameManager.gm;
        alertImage = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

        if (gm.canPlayerMove()) {
            alertImage.color = Color.white;
        } else {
            alertImage.color = Color.clear;
        }
	}
}
