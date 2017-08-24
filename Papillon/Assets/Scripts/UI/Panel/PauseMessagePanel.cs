using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMessagePanel : MonoBehaviour {

    public Text msg;

    public void setText(string text) {
        msg.text = text;
    }

    public void close() {
        Destroy(gameObject);
    }
}
