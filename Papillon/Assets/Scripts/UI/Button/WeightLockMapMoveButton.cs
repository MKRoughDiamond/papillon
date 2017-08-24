using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeightLockMapMoveButton : MonoBehaviour {

    public int scene;

    private GameManager gm;
    private Player player;

	// Use this for initialization
	void Start () {
        gm = GameManager.gm;
        player = gm.getPlayer();
	}
	
	public void onClick() {
        if (player.isOverLoaded()) {
            gm.showMessage("무거워서 이동할 수 없습니다.");
            return;
        }

        SceneManager.LoadScene(scene);
    }
}
