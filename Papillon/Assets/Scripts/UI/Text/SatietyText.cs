using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatietyText : MonoBehaviour {

    private Player player;

    public Text satietyText;

    void Start() {
        player = GameManager.gm.getPlayer();
    }

    private void Update() {
        satietyText.text = player.getSatiety().ToString() + "/" + player.getMaxSatiety();
    }
}
