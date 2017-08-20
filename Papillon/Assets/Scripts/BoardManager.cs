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
            case SCENES.MAP:
                mapSetup();
                break;
            case SCENES.BASE:
                baseSetup();
                break;
            default:
                break;
        }
    }

    // if day changed
    public void nextDay(int scene, int day) {
        if(scene == SCENES.MAP) {
            if(day%3==0)
                if (!map.destroyFrontField())
                    gm.gameOver();
            map.displayMap();
        }
    }

    public Map getMap() {
        return map;
    }

    private void fieldSetup()
    {
        // 상당히 안 좋은 구조...
        FieldGenerator fieldGenerator = GameObject.Find("FieldGenerator").GetComponent<FieldGenerator>();
        Field field = map.getPlayerPositionField();
        fieldGenerator.displayField(field);

        gm.useExploreChance();
    }

    private void baseSetup()
    {
        return;
    }

    private void mapSetup()
    {
        map.displayMap();     
    }
}
