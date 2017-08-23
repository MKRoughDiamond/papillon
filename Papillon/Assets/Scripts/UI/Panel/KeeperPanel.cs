using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperPanel : Panel {

    private GameManager gm;
    private Player player;
    private Base baseObject;
    private List<InventoryElement> playerInventory;
    private List<InventoryElement> baseInventory;

    private string baseElementParent = "BaseInventory/Scroll/Viewport/Slots";
    private string playerElementParent = "PlayerInventory/Scroll/Viewport/Slots";

    // must be 'Awake' not 'Start' because this must be called before 'OnEnable', 'OnDisable'
    private void Awake() {
        gm = GameManager.gm;
        baseObject = gm.getBoardManager().getBase();
        player = gm.getPlayer();
        playerInventory = player.getInventory();
        baseInventory = baseObject.getInventory();
        gameObject.SetActive(false);
    }

    private void drawInventory() {
        // show plaerInventory
        foreach(InventoryElement e in playerInventory) {
            GameObject slot = Instantiate(panelElement, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
            slot.transform.SetParent(transform.Find(playerElementParent));
            slot.GetComponent<KeeperSlot>().init(e, KEEPERSLOTTYPE.PLAYER);
        }

        foreach(InventoryElement e in baseInventory) {
            GameObject slot = Instantiate(panelElement, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
            slot.transform.SetParent(transform.Find(baseElementParent));
            slot.GetComponent<KeeperSlot>().init(e, KEEPERSLOTTYPE.BASE);
        }
    }

    private void clearInventory() {
        Transform parent = transform.Find(playerElementParent);
        foreach (Transform t in parent) {
            Destroy(t.gameObject);
        }

        parent = transform.Find(baseElementParent);
        foreach (Transform t in parent) {
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
