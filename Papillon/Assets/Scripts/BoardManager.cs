using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    private GameManager gm;
    private Map map;

    private List<Base> bases;
    private int currentBaseId;

    public void init()
    {
        gm = GameManager.gm;
        map = GetComponent<Map>();
        map.init();
        bases = new List<Base>();
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
            if (day % 3 == 0)
                if (!map.destroyFrontField())
                    gm.gameOver();
                else
                    map.displayMap();
            else
                map.displayMap();
        }
    }

    public Map getMap() {
        return map;
    }

    public Base getBase() {
        Field field = map.getPlayerPositionField();
        currentBaseId = field.getIndex();

        for(int i = 0; i < bases.Count; i++) {
            if (bases[i].getId() == currentBaseId) {
                return bases[i];
            }
        }

        Debug.Log("ERROR: getbase() Illegal Base Id");
        return new Base(-1);
    }

    public void addBase(int idx) {
        bases.Add(new Base(idx));
    }

    private void fieldSetup()
    {
        // 상당히 안 좋은 구조...
        FieldGenerator fieldGenerator = GameObject.Find("FieldGenerator").GetComponent<FieldGenerator>();
        Field field = map.getPlayerPositionField();
        fieldGenerator.displayField(field);

        // if a field is the rocket field, check game end
        if(field.getType() == FIELDTYPE.ROCKET) {
            gm.checkRocketLaunch(field);
        }

        gm.useExploreChance();
    }

    private void baseSetup() {
        gm.playBGM("base");
        getBase().updateBaseStates(gm.getDay());
        return;
    }

    private void mapSetup()
    {
        gm.playBGM("map");
        map.displayMap();     
    }
}
