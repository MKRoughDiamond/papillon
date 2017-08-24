using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 아이템을 드랍하는 오브젝트에 부착하는 클래스
/// </summary>
public class ItemHolder : MonoBehaviour {

    public FieldItemElement possesion;
    public Sprite icon;
    public Sprite damagedIcon;

    private GameManager gm;
    private Player player;

    private Image fieldPanelImage;
    private Text fieldPanelText;

    private void Awake() {
        gm = GameManager.gm;
        player = gm.getPlayer();
    }

    public void setPanel(Image panelImage, Text panelText) {
        fieldPanelImage = panelImage;
        fieldPanelText = panelText;
    }

    public void setItem(FieldItemElement e) {

        if(e.currentCount < 1) {
            destroyItem();
        }

        possesion = e;
        loadIcon(possesion.item.getName());
    }

    private void loadIcon(string name) {
        Sprite newIcon = Resources.Load<Sprite>("Icon/ItemHolder/" + name);
        Sprite newDamagedIcon = Resources.Load<Sprite>("Icon/ItemHolder/" + name + "_damaged");

        if (newIcon) {
            icon = newIcon;
            gameObject.GetComponent<Image>().sprite = icon;
        } else
            Debug.Log("There is no ItemHolder icon\t" + name);

        if (newDamagedIcon) {
            damagedIcon = newDamagedIcon;
        } else
            Debug.Log("There is no ItemHolder damagedIcon\t" + name);
    }

    // change icon to damaged icon
    private void changeIcon() {
        gameObject.GetComponent<Image>().sprite = damagedIcon;
    }

    // drop one item is holds
    public void dropItem() {
        ItemEffect itemEffect = possesion.getItem().getEffect();
        
        if(!player.addItem(possesion.item.getId(), 1)) {
            return;
        }
        player.changeSatiety(SATIETYPOINTS.COLLECT);

        updateFieldPanel(possesion.item);
        possesion.currentCount--;

        if (possesion.item.getType() == ITEMTYPE.USABLE)
            gm.playSE("collect-soft");
        else
            gm.playSE("collect-hard");


        if (itemEffect != null && itemEffect.name.Equals("Damage_With_Prob"))
            gm.doEffect(itemEffect);
        
        if(possesion.currentCount < 1) {
            destroyItem();
        } else if (possesion.currentCount * 2 <= possesion.totalCount) {
            changeIcon();
        }
    }

    // drop all item is holds
    public void dropAllItems() {
        player.addItem(possesion.item.getId(), possesion.currentCount);
        destroyItem();
    }

    private void destroyItem() {
        // someDestoryEvent();
        Destroy(gameObject);
    }

    private void updateFieldPanel(Item item) {
        fieldPanelImage.sprite = item.getIcon();
        fieldPanelText.text = item.getName();
    }
}
