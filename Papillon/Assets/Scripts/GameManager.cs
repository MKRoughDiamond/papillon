using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager gm = null;

    private BoardManager boardManager;
    private CraftManager craftManager;
    private ResearchManager researchManager;
    private Player player;

    public GameObject inventory;

    private int scene;

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

        /*
         *  Initializing player
         *  TODO: Better initialize different way.
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

        // start game
        initGame();
    }

    private void initGame() {
        SceneManager.LoadScene(scene);
        boardManager.boardSetup(scene);
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
}

//SCENES
/*
 * FIELD                          0
 * LAB(FOR RESEARCH)              1
 * FACTORY(FOR PRODUCTION)        2
 * FARM(FOR FARMING)              3
 * MAP                            4
 */

public static class SCENES {
    public const int FIELD = 0;
    public const int LAB = 1;
    public const int FACTORY = 2;
    public const int FARM = 3;
    public const int MAP = 4;
    public const int MAIN = 5;
}
