using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Panel 최상위 클래스
/// </summary>
public class Panel : MonoBehaviour {

    public GameObject panelElement;

    // open panel
    // display all things
    public virtual void open() {
        gameObject.SetActive(true);
    }

    // close panel
    public virtual void close() {
        gameObject.SetActive(false);
    }

}
