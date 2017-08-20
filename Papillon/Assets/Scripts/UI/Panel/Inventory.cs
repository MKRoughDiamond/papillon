using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : Panel {

    private GameManager gm;
    private Player player;
    private List<InventoryElement> playerInventory;
    private string elementParent = "Scroll/Viewport/Slots"; // transform where slots will be attached

    // must be 'Awake' not 'Start' because this must be called before 'OnEnable', 'OnDisable'
    private void Awake() {
        gm = GameManager.gm;
        player = gm.getPlayer();
        playerInventory = player.getInventory();

        gameObject.SetActive(false);
    }

    // show inventory
    private void drawInventory() {
        foreach(InventoryElement e in playerInventory) {
            GameObject slot = Instantiate(panelElement, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
            slot.transform.SetParent(transform.Find(elementParent));
            slot.GetComponent<Slot>().init(e);
            slot.GetComponent<Image>().sprite = slot.GetComponent<Slot>().icon;
        }
    }

    private void clearInventory() {
        Transform parent = transform.Find(elementParent);
        foreach(Transform t in parent) {
            Destroy(t.gameObject);
        }
    }

    public void updateInventory() {
        clearInventory();
        drawInventory();
    }

    private void OnEnable() {
        updateInventory();
    }

    private void OnDisable() {
        clearInventory();
    }
}