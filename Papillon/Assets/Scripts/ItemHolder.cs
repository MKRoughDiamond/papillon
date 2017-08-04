using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 아이템을 드랍하는 오브젝트에 부착하는 클래스
/// </summary>
public class ItemHolder : MonoBehaviour {

    public int itemId;
    public int count;

    private GameManager gm;
    private Player player;

    private void Awake() {
        gm = GameManager.gm;
        //player = gm.getPlayer();
    }

    public void dropItem() {
        player.getItems(itemId, 1);
        count--;

        if(count < 1) {
            destroyItem();
        }
    }

    public void dropAllItems() {
        player.getItems(itemId, count);
        destroyItem();
    }

    private void destroyItem() {
        // someDestoryEvent();
        Destroy(gameObject);
    }
}
