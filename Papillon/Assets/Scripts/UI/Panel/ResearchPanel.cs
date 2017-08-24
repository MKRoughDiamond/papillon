using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchPanel : Panel {

    private GameManager gm;
    private ResearchManager rm;
    private string elementParent;

    private string state;

    // must be 'Awake' not 'Start' because this must be called before 'OnEnable', 'OnDisable'
    private void Awake() {
        gm = GameManager.gm;
        rm = gm.getResearchManager();
        elementParent = "Scroll/Viewport/ResearchList";
        state = "AVAILABLE";    // which pane if currently displayed

        gameObject.SetActive(false);
    }

    // construct research list that will be shown on the panel
    public void makeResearchList() {

        clearList();

        List<Technology> techList;

        switch (state) {
            case "LOCKED":
                techList = rm.getLockedList();
                break;
            case "AVAILABLE":
                techList = rm.getAvailableList();
                break;
            case "DONE":
                techList = rm.getDoneList();
                break;
            default:
                Debug.Log("Wrong makeResearchList() call");
                techList = new List<Technology>();
                break;
        }

        foreach(Technology tech in techList) {
            // Generate elements
            GameObject element = Instantiate(panelElement);
            element.GetComponent<ResearchPanelElement>().init(tech);

            // Attach it to panel scroll list
            // If you change name of object in inspector, you must change below code
            element.transform.SetParent(transform.Find(elementParent));

        }

        setButtonColor();

    }

    private void setState(string newState) {
        state = newState;
    }

    public string getState() {
        return state;
    }

    private void clearList() {
        Transform parent = transform.Find(elementParent);
        foreach (Transform t in parent) {
            Destroy(t.gameObject);
        }
    }

    // when disabled, remove all list
    private void OnDisable() {
        clearList();
    }

    // when enabled ( default list is 'AVAILABLE' )
    private void OnEnable() {
        setState("AVAILABLE");
        makeResearchList();
    }

    public override void switchPane(string paneName) {
        setState(paneName);
        makeResearchList();
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
