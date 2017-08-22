using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CultivatePanelElement : MonoBehaviour {

    private GameManager gm;
    private Base baseObject;

    public Text name;
    public Text day;
    public Text product;
    public Image icon;

    private CultivatePanel panel;
    private CultivateElement element;

    public void init(CultivateElement element) {

        panel = GetComponentInParent<CultivatePanel>();
        gm = GameManager.gm;
        baseObject = gm.getBoardManager().getBase();
        this.element = element;

        name.text = this.element.getItem().getName();
        day.text = generateDayText();
        product.text = generateProductText(this.element.getItem().getEffect());
        icon.sprite = this.element.getItem().getIcon();
    }

    private string generateDayText() {

        int requiredDay = element.getRequiredDay();
        int passedDay = Mathf.Min(gm.getDay() - element.getStartDay(), requiredDay);

        return passedDay.ToString() + " / " + requiredDay.ToString();
    }

    private string generateProductText(ItemEffect effect) {
        string text = "";
        List<int> param = effect.parameters;

        string product = ItemDatabase.findNameById(param[1]);
        int productCount = param[2];
        string seed = ItemDatabase.findNameById(param[3]);
        int seedCount = param[4];

        text += product + " x " + productCount.ToString() + '\n';
        text += seed + " x " + seedCount.ToString();

        return text;
    }

    public void onClick() {
        // start cultivating
        if (panel.getState() == "SEED") {
            baseObject.cultivate(element.getItem(), gm.getDay());
            panel.makeList();
        } else if(panel.getState() == "CULTIVATING") {
            // do nothing
        } else if(panel.getState() == "DONE") {
            baseObject.harvest(element.getItem().getId());
            panel.makeList();
        }
    }
}
