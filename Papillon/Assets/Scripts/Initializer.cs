using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour {

    private void Start() {
        if(GameManager.gm != null) {
            Destroy(GameManager.gm.gameObject);
            GameManager.gm = null;
        }
    }
}
