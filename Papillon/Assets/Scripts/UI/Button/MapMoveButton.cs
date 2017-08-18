using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMoveButton : MonoBehaviour {
 
    // Set up in inspector
    public int scene;

    // load scene
    public void onClick() {
        SceneManager.LoadScene(scene);
    }
}
