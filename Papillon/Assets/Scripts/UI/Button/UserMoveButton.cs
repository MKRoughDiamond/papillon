using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMoveButton : MonoBehaviour {

    private GameManager gm;
    private Vector2 position;

    private void Start() {
        gm = GameManager.gm;
    }

    public void updatePosition(int x, int y) {
        this.position = new Vector2(x, y);
    }

    public void onClick() {
        Map map = gameObject.GetComponentInParent<Map>();

        if (gm.canPlayerMove()) {    
            // try move
            if (map.movePlayer(position)) {
                // sucess
                gm.playSE("step");
                gm.useMoveChance();
                map.displayMap();
            } else {
                // fail
                gm.showMessage("바로 이동할 수 없는 장소다.");
            }

        } else if (!gm.canPlayerMove()) {
            gm.showMessage("오늘 더 움직이는 것은 무리다.");
        }
    }
}
