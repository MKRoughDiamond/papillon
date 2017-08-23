using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

    public Image icon;
    public Text count;

    protected string name;
    protected string description;

    public string getName() {
        return name;
    }

    public string getDescription() {
        return description;
    }

}
