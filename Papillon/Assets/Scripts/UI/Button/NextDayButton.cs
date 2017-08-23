using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDayButton : MonoBehaviour {

    GameManager gm;

    private bool alert;

    private void Start() {
        gm = GameManager.gm;
        alert = false;
    }

    public void onClick() {

        // yes this is hard coding!!!! HAHAHAHAHAHAHA

        // BLACKHOLE MOVE CONDITION
        if (gm.isBlackholeMoveTurn(gm.getDay() + 1)) {
            // player is just in front of blackhole
            if(gm.getBoardManager().getMap().getDistance() == 1 && !alert) {
                gm.showMessage("이대로 다음 날로 가면 블랙홀에 잡아먹힙니다.\n 살아남을 방법을 궁리해주세요.");
                alert = true;
                return;
            }
        } else {
            alert = false;
        }

        gm.goNextDay();
    }
}
