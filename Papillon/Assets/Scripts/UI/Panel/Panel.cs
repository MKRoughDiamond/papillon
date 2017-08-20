using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Panel 최상위 클래스
/// </summary>
public class Panel : MonoBehaviour {

    // panel consists of multiple layout of panelElements
    public GameObject panelElement;

    // switch open/close state
    public virtual void switchPanel() {
        if (gameObject.activeInHierarchy) {
            close();
        }
        else {
            open();
        }
    }

    // open panel
    // display all things
    public virtual void open() {
        gameObject.SetActive(true);
    }

    // close panel
    public virtual void close() {
        gameObject.SetActive(false);
    }

    // panels might have multiple panes or not
    public virtual void switchPane(string paneName) {
        return;
    }

}
