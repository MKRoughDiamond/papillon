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
        float currWeight = player.getItemWeight();
        if(currWeight > player.getMaxItemWeight()*0.9) {
            inventoryText.color = Color.red;
        } else {
            inventoryText.color = originalColor;
        }

        if ((int)currWeight == currWeight)
            inventoryText.text = currWeight.ToString() + "/" + player.getMaxItemWeight();
        else {
            if (currWeight < 1)
                inventoryText.text = "0" + currWeight.ToString("#.00") + "/" + player.getMaxItemWeight();
            else
                inventoryText.text = currWeight.ToString("#.00") + "/" + player.getMaxItemWeight();
        }
    }
}
