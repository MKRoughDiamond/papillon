using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    private GameManager gm;
    private Map map;

    public void init()
    {
        gm = GameManager.gm;
        map = GetComponent<Map>();
        map.init();
    }

    public void boardSetup(int scene) {

        map.clearMap();

        switch (scene) {
            case SCENES.FIELD:
                fieldSetup();
                break;
            case SCENES.FACTORY:
                factorySetup();
                break;
            case SCENES.LAB:
                labSetup();
                break;
            case SCENES.FARM:
                farmSetup();
                break;
            case SCENES.MAP:
                mapSetup();
                break;
        }
    }

    private void fieldSetup()
    {
        FieldGenerator fieldGenerator = GameObject.Find("FieldGenerator").GetComponent<FieldGenerator>();
        Field field = map.getPlayerPositionField();
        fieldGenerator.displayField(field);
    }

    private void factorySetup()
    {
        return;
    }

    private void labSetup()
    {
        return;
    }

    private void farmSetup()
    {
        return;
    }

    private void mapSetup()
    {
        map.displayMap();
        Debug.Log("display map");
    }
}
