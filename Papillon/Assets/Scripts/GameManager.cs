using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager gm = null;

    private BoardManager boardManager;
    private CraftManager craftManager;
	
    private ItemDatabase itemDB;
    private Player player;
    private int scene;

    private void Start() {

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
        RecipeDatabase.init();

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

        // default scene
        scene = SCENES.MAP;

        // start game
        initGame();
    }

    private void initGame() {
        SceneManager.LoadScene(scene);
        boardManager.boardSetup(scene);
    }

    public Player getPlayer() {
        return player;
    }

    public CraftManager getCraftManager() {
        return craftManager;
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
