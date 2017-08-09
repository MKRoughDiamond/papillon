using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 전체 맵을 나타내며 해당 신에서 필요한 여러 작업들을 수행하는 클래스
/// </summary>
public class Map : MonoBehaviour {

    private List<List<Field>> fields;
    private Vector2 playerPosition;     // current position of the player

    public GameObject fieldIcon;
    public GameObject userIcon;

    public Map() {
        fields = new List<List<Field>>();
    }

    public void init() {
        fields.Add(new List<Field>());
        fields[0].Add(new Field(FIELDTYPE.WILD));
        playerPosition = new Vector2(0, 0);
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

    // display map on the scene
    public void displayMap() {

        // remove currently displaying fields
        foreach(Transform t in transform) {
            Destroy(t.gameObject);
        }

        // display fields
        for(int x=0; x<fields.Count; x++) {
            for(int y=0; y<fields[x].Count; y++) {
                if(playerPosition.x == x && playerPosition.y == y) {
                    generateField(userIcon, x, y);
                } else {
                    generateField(fieldIcon, x, y);
                }
            }
        }
    }

    private void generateField(GameObject icon, int x, int y) {

        int padx = 50;
        int pady = 50;

        GameObject field = Instantiate(icon, new Vector3(x * padx, y * pady, 0), Quaternion.identity) as GameObject;
        field.GetComponent<UserMoveButton>().updatePosition(x, y);
        field.transform.parent = transform;

        // might be better solution?...
        field.transform.localPosition = new Vector3(x * padx, y * pady, 0);
    }

    public List<List<Field>> getFields() {
        return fields;
    }
}

