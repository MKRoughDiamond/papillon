using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeRotator : MonoBehaviour {

    RectTransform r;

	void Start () {
        r = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        r.Rotate(new Vector3(0, 0, 1));
	}
}
