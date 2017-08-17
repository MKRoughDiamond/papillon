using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 전체 맵을 나타내며 해당 신에서 필요한 여러 작업들을 수행하는 클래스
/// </summary>
public class Map : MonoBehaviour {

    
    private List<List<Field>> fields;
    private Vector2 playerPosition;     // current position of the player
    private int eyesight = 7;           // eyesight of player

    public GameObject canvas;
    public GameObject fieldIcon;
    public GameObject userIcon;

    public void init() {

        fields = new List<List<Field>>();
        for (int i = 0; i < eyesight * 2; i++)
            generateMap(i);
        playerPosition = new Vector2(1, 0);
    }

    public void generateMap(int x)
    {
        Debug.Log("Asdf");
        if(x % 2 == 0)
        {

            fields.Add(new List<Field>());
            for (int i = 0; i < Random.Range(1, 5); i++)
                fields[x].Add(new Field(FIELDTYPE.WILD));
        }
        else
        {
            fields.Add(new List<Field>());
            fields[x].Add(new Field(FIELDTYPE.WILD));
        }
    }

    // move player position
    public bool movePlayer(Vector2 position) {
        
        // trying to move irregular position
        if(Mathf.Abs(playerPosition.x - position.x) != 1) {
            return false;
        }

        // TODO : implement
        // if (noMoreMoveChance)
        //  return false;

        playerPosition = position;
        return true;
    }

    // distory map by blackhole
    public bool destroyFrontField() {
        
        // TODO : implement
        //if (playerPosition.x == 0) {
        //    gameOver()
        //}

        fields.RemoveAt(0);
        playerPosition = new Vector2(playerPosition.x - 1, playerPosition.y);

        return true;
    }

    // remove currently displaying fields
    public void clearMap() {
        foreach (Transform t in canvas.transform) {
            Destroy(t.gameObject);
        }
    }

    // display map on the scene
    public void displayMap() {
        int leftMost = (playerPosition.x - 1 < 0) ? 0 : (int)playerPosition.x - 1;
        clearMap();

        // display fields
        for(int x=leftMost; x< leftMost+eyesight; x++) {
            if(x >= fields.Count)
                generateMap(x);
            for (int y=0; y< fields[x].Count; y++) {
                if (playerPosition.x == x && playerPosition.y == y)
                {
                    generateField(userIcon, x, y);
                }
                else
                {
                    generateField(fieldIcon, x, y);
                }
            }
        }
    }

    private void generateField(GameObject icon, int x, int y) {

        int startx = -400;
        int starty = 0;
        int padx = 100;
        int pady = 50;

        GameObject field = Instantiate(icon, new Vector3(startx + (x-playerPosition.x+2) * padx, starty + (y - (fields[x].Count / 2)) * pady, 0), Quaternion.identity) as GameObject;
        field.GetComponent<UserMoveButton>().updatePosition(x, y);
        field.transform.SetParent(canvas.transform, false);

        // might be better solution?...
        //field.transform.localPosition = new Vector3(x * padx, y * pady, 0);
    }

    public List<List<Field>> getFields() {
        return fields;
    }
}

