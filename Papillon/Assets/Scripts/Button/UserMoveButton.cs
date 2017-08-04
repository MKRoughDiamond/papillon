using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMoveButton : MonoBehaviour {

    private Vector2 position;

    public void updatePosition(int x, int y) {
        this.position = new Vector2(x, y);
    }

    public void onClick() {
        Map map = gameObject.GetComponentInParent<Map>();
        map.movePlayer(position);
        map.displayMap();
    }
}
