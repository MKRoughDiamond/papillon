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
        if (gm.canPlayerMove()) {
            gm.useMoveChance();

            Map map = gameObject.GetComponentInParent<Map>();
            map.movePlayer(position);
            map.displayMap();
        }
    }
}
