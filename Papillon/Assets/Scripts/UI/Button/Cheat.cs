using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour {

    GameManager gm;
    BoardManager bm;
    Player player;
    CraftManager cm;
    ResearchManager rm;

    public void onClick() {
        gm = GameManager.gm;
        cm = gm.getCraftManager();
        bm = gm.getBoardManager();
        player = gm.getPlayer();

        player.addItem(1, 10);
        player.addItem(3, 10);
        player.addItem(4, 10);
        player.addItem(5, 10);
        player.addItem(5, 10);
        player.addItem(6, 10);
        player.addItem(7, 10);
        player.addItem(8, 10);
        player.addItem(15, 1);

        player.addItem(105, 10);

        player.addItem(300, 100);
    }
}
