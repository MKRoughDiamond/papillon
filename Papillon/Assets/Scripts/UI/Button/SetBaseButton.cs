using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBaseButton : MonoBehaviour {

    Map map;

    private void Start() {
        map = GameManager.gm.getBoardManager().getMap();
    }

    public void onClick() {
        map.setBase();
    }
}
