using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackholeText : MonoBehaviour {
    
    public Text blackholeText;
    private GameManager gm;
    private BoardManager bm;
    private Map map;

    private Color originalColor;
    
    // Use this for initialization
    void Start () {
        gm = GameManager.gm;
        bm = gm.getBoardManager();
        map = bm.getMap();

        originalColor = blackholeText.color;
    }
	
	// Update is called once per frame
	void Update () {

        if (map.getDistance() < 2) {
            blackholeText.color = Color.red;
        } else {
            blackholeText.color = originalColor;
        }

        blackholeText.text = map.getDistance().ToString();	
	}
}