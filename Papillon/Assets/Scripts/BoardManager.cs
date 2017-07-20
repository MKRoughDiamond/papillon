﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    private GameManager gm;

    private void Awake() {
        gm = GameManager.gm;
    }

    public void boardSetup(int scene) {
        switch (scene) {
            case SCENES.ITEMCOLLECT:
                itemCollectSetup();
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

    private void itemCollectSetup()
    {
        return;
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
        return;
    }
}