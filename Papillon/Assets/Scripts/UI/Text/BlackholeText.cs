using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackholeText : MonoBehaviour {
    
    public Text blackholeText;
    private GameManager gm;
    private BoardManager bm;
    private Map map;
    // Use this for initialization
    void Start () {
        gm = GameManager.gm;
        bm = gm.getBoardManager();
        map = bm.getMap();
    }
	
	// Update is called once per frame
	void Update () {
        blackholeText.text = "Blackhole : behind " + (map.getDistance()) + " section(s)";	
	}
}