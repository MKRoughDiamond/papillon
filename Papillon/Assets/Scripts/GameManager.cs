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
        scene = SCENES.RESEARCH;

        initGame();
    }

    private void initGame() {
        boardManager.boardSetup(scene);
    }
}

public static class SCENES {
    public const int RESEARCH = 0;
}
