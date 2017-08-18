﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager gm = null;

    private BoardManager boardManager;
    private CraftManager craftManager;
    private ResearchManager researchManager;
    private Player player;
    private GameObject inventory;
    private int scene;

    // game play related variables
    public int day;
    public bool exploreChance;  // whether player can go field or not
    public bool moveChance;     // whether player can move map or not
    

    // think this better be Awake.
    private void Awake() {

        /*
         * GameManager Base Initializing
         */

        // Singleton object
        if (gm == null)
            gm = this;
        else if (gm != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        // initialize game
        initGame();
    }

    private void initGame() {

        /*
         *  Initializing player
         *  
         */
        player = new Player(100, 100, 0, 100f);

        /*
         * Initializing Databases
         * 
         */
        ItemDatabase.init();
        FieldDropDatabase.init();
        RecipeDatabase.init();
        TechnologyDatabase.init();

        /*
         * Other Managers Initializing
         * 
         * **CAUTION**
         * You must initialize managers after initializing databases, player
         * because initializing managers contain loading object, data from database, player
         */
        boardManager = GetComponent<BoardManager>();
        boardManager.init();
        craftManager = GetComponent<CraftManager>();
        craftManager.init();
        researchManager = GetComponent<ResearchManager>();
        researchManager.init();

        /*
         * get Inventory
         */

        inventory = transform.Find("Canvas/InventoryPanel").gameObject;

        // default scene
        scene = SCENES.MAP;

        // game play variables initialize
        day = 0;
        exploreChance = true;
        moveChance = true;

        // start game
        SceneManager.LoadScene(scene);
    }

    private void OnLevelWasLoaded (int level) {
        boardManager.boardSetup(level);
    }

    public Player getPlayer() {
        return player;
    }

    public BoardManager getBoardManager() {
        return boardManager;
    }

    public CraftManager getCraftManager() {
        return craftManager;
	}

    public ResearchManager getResearchManager() {
        return researchManager;
    }

    public GameObject getInventory() {
        return inventory;
    }

    /*
     * Game Play Related Methods
     */

    public int getDay() {
        return day;
    }

    // go to next day
    public void goNextDay() {
        day += 1;
        exploreChance = true;
        moveChance = true;

        boardManager.nextDay(scene);
    }

    // check player can explore
    public bool canPlayerExplore() {
        return exploreChance;
    }

    // check player can move
    public bool canPlayerMove() {
        return moveChance;
    }

    /*
     * use explore chance
     *  - when user go to field
     *  - when user built base
     *  - when user do some research in base
     */
    public void useExploreChance() {
        exploreChance = false;
    }

    /*
     *  use move chance
     */
    public void useMoveChance() {
        moveChance = false;
    }
}

//SCENES
public static class SCENES {
    public const int FIELD = 0;
    public const int MAP = 1;
    public const int BASE = 2;
    //public const int LAB = 1;
    //public const int FACTORY = 2;
    //public const int FARM = 3;
    //public const int MAP = 4;
    //public const int MAIN = 5;
}
