using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBaseButton : MonoBehaviour {
    GameManager gm;
    CraftManager cm;
    Map map;

    private void Start() {
        gm = GameManager.gm;
        cm = gm.getCraftManager();
        map = gm.getBoardManager().getMap();
    }

    public void onClick() {
        if(cm.craft(1000,1))
            map.setBase();
    }
}
