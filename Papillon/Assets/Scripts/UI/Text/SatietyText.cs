using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatietyText : MonoBehaviour {

    private Player player;

    public Text satietyText;

    private Color originalColor;

    void Start() {
        player = GameManager.gm.getPlayer();
        originalColor = satietyText.color;
    }

    private void Update() {

        if(player.getSatiety() * 10 < player.getMaxSatiety()) {
            satietyText.color = Color.red;
        } else {
            satietyText.color = originalColor;
        }

        satietyText.text = player.getSatiety().ToString() + "/" + player.getMaxSatiety();
    }
}
