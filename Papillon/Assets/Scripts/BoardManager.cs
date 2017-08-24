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
        map.setBase(true);
        firstBaseSetup();
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
        if (gm.isBlackholeMoveTurn(day)) {
            if (!map.destroyFrontField()) {
                gm.gameOver();
                return;
            } 
        } 

        if(scene == SCENES.MAP) {
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
        gm.playSE("step");

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

    private void firstBaseSetup(){
        Base firstBase = getBase();
        firstBase.addItem(ItemDatabase.findIdByName("통조림"), Random.Range(1, 3));
        firstBase.addItem(ItemDatabase.findIdByName("의약품"), Random.Range(1, 3));
        firstBase.addItem(ItemDatabase.findIdByName("연료"), Random.Range(-2, 6));
        firstBase.addItem(ItemDatabase.findIdByName("티타늄 주괴"), Random.Range(-8, 1));
        firstBase.addItem(ItemDatabase.findIdByName("철 주괴"), Random.Range(-8, 1));
    }

    private void mapSetup()
    {
        gm.playBGM("map");
        map.displayMap();     
    }
}
