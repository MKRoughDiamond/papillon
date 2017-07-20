using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gm = null;

    private BoardManager boardManager;
    private int scene;

    private void Awake() {
        
        // Singleton object
        if (gm == null)
            gm = this;
        else if (gm != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        boardManager = GetComponent<BoardManager>();
        scene = SCENES.ITEMCOLLECT;

        initGame();
    }

    private void initGame() {
        boardManager.boardSetup(scene);
    }
}

//SCENES
/*ITEMCOLLECT                    0
  FACTORY(FOR PRODUCTION)        1
  LAB(FOR RESEARCH)              2
  FARM(FOR FARMING)              3
  MAP                            4 */
    
public static class SCENES {
    public const int ITEMCOLLECT = 0;
    public const int FACTORY = 1;
    public const int LAB = 2;
    public const int FARM = 3;
    public const int MAP = 4;
}
