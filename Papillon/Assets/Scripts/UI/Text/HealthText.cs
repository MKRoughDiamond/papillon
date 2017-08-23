using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour {

    private Player player;

    public Text healthText;

    void Start() {
        player = GameManager.gm.getPlayer();
    }

    private void Update() {
        healthText.text = player.getHealth().ToString() + "/" + player.getMaxHealth();
    }
}
