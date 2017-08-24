using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CultivatePanel : Panel {

    private GameManager gm;
    private BoardManager bm;
    private Player player;

    private string elementParent;
    private string state;

    // must be 'Awake' not 'Start' because this must be called before 'OnEnable', 'OnDisable'
    private void Awake() {
        gm = GameManager.gm;
        bm = gm.getBoardManager();
        player = gm.getPlayer();

        elementParent = "Scroll/Viewport/CultivateList";
        state = "CULTIVATING";

        gameObject.SetActive(false);
    }

    public string getState() {
        return state;
    }

    private void setState(string newState) {
        state = newState;
    }

    public void makeList() {
        
        clearList();

        List<CultivateElement> list;
        Base baseObject = bm.getBase();
        int day = gm.getDay();

        switch (state) {
            case "SEED":
                list = baseObject.getSeedList(day);
                break;
            case "CULTIVATING":
                list = baseObject.getCultivatingList();
                break;
            case "DONE":
                list = baseObject.getDoneList();
                break;
            default:
                Debug.Log("Wrong makeList() call");
                list = new List<CultivateElement>();
                break;
        }

        foreach (CultivateElement e in list) {
            // Generate elements
            GameObject element = Instantiate(panelElement) as GameObject;

            // Attach it to panel scroll list
            // If you change name of object in inspector, you must change below code
            element.transform.SetParent(transform.Find(elementParent));

            element.GetComponent<CultivatePanelElement>().init(e);
        }

        setButtonColor();
    }

    public void clearList() {
        Transform parent = transform.Find(elementParent);
        foreach (Transform t in parent) {
            Destroy(t.gameObject);
        }
    }

    // when disabled, remove all list
    private void OnDisable() {
        clearList();
    }

    // when enabled ( default list is 'CULTIVATING' )
    private void OnEnable() {
        setState("CULTIVATING");
        makeList();
    }

    public override void switchPane(string paneName) {
        setState(paneName);

        makeList();
    }

    // set pane button color
    private void setButtonColor() {
        
        // yes this it hardcoding!

        PanelPaneSwitchButton[] buttons = GetComponentsInChildren<PanelPaneSwitchButton>();

        var originalColor = Color.white;

        foreach (PanelPaneSwitchButton b in buttons) {
            if (b.paneName == state) {
                var color = b.gameObject.GetComponent<Button>().colors;
                color.normalColor = Color.black;
                color.highlightedColor = Color.black;
                b.gameObject.GetComponent<Button>().colors = color;
            } else {
                var color = b.gameObject.GetComponent<Button>().colors;
                color.normalColor = originalColor;
                color.highlightedColor = originalColor;
                b.gameObject.GetComponent<Button>().colors = color;
            }
        }
    }
}
