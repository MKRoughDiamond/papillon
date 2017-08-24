using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryText : MonoBehaviour {

    private Player player;

    public Text inventoryText;

    private Color originalColor;

    void Start() {
        player = GameManager.gm.getPlayer();
        originalColor = inventoryText.color;
    }

    private void Update() {

        if(player.getItemWeight() > player.getMaxItemWeight()*0.9) {
            inventoryText.color = Color.red;
        } else {
            inventoryText.color = originalColor;
        }

        inventoryText.text = player.getItemWeight().ToString() + "/" + player.getMaxItemWeight();
    }
}
