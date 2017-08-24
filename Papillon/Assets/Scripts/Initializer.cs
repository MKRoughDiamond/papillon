using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initializer : MonoBehaviour {

    private void Start() {
        Screen.SetResolution(1280, 720, false);
        if (GameManager.gm != null) {
            Destroy(GameManager.gm.gameObject);
            GameManager.gm = null;
        }
    }
}
