using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour {

    private Player player;

    public Text healthText;

    private Color originalColor;

    void Start() {
        player = GameManager.gm.getPlayer();
        originalColor = healthText.color;
    }

    private void Update() {

        if (player.getHealth() * 5 < player.getMaxHealth()) {
            healthText.color = Color.red;
        } else {
            healthText.color = originalColor;
        }

        healthText.text = player.getHealth().ToString() + "/" + player.getMaxHealth();
    }
}
