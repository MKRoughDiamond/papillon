using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldGenerator : MonoBehaviour {
    
    private int fieldSizeX = 10;
    private int fieldSizeY = 10;
    private int tileSize = 64;

    private int startX = 20;
    private int startY = 20;

    public Canvas canvas;
    public Image fieldPanelImage;
    public Text fieldPanelText;

    public GameObject[] forestTiles;
    public GameObject[] factoryTiles;
    public GameObject[] residentialTiles;

    public GameObject itemHolder;

    private GameManager gm;
    private BoardManager bm;

    private void Start() {
        gm = GameManager.gm;
        // bm = gm.getBoardManager();
    }

    public void displayField(Field field) {

        // display tiles
        displayTiles(field.getType());

        // display itemHolders
        displayItemHolders(field.getItemList());
    }

    // display tiles
    private void displayTiles(int type) {
        GameObject[] tiles = getTiles(type);
        int len = tiles.Length;

        for (int x = 0; x < fieldSizeX; x++) {
            for (int y = 0; y < fieldSizeY; y++) {
                GameObject tile = Instantiate(tiles[Random.Range(0, len)], new Vector3(startX + x * tileSize, startY + y * tileSize, 0), Quaternion.identity) as GameObject;
                tile.transform.SetParent(transform, false);
            }
        }
    }

    // display itemHolders
    private void displayItemHolders(List<FieldItemElement> itemList) {

        // possible position list ( to prevent position duplicate )
        List<Vector3> positions = new List<Vector3>();
        for (int x = 0; x < fieldSizeX; x++) {
            for (int y = 0; y < fieldSizeY; y++) {
                positions.Add(new Vector3(startY + x * tileSize, startY + y * tileSize, 0f));
            }
        }

        // deposite itemHolders
        for(int i = 0; i < itemList.Count; i++) {
            int idx = Random.Range(0, positions.Count);
            Vector3 position = positions[idx];

            GameObject holder = Instantiate(itemHolder, position, Quaternion.identity) as GameObject;
            holder.GetComponent<ItemHolder>().setItem(itemList[i]);
            holder.GetComponent<ItemHolder>().setPanel(fieldPanelImage, fieldPanelText);
            holder.transform.SetParent(transform, false);
            positions.RemoveAt(idx);
        }
    }

    private GameObject[] getTiles(int type) {
        switch (type) {
            case FIELDTYPE.FOREST:
                return forestTiles;
            case FIELDTYPE.FACTORY:
                return factoryTiles;
            case FIELDTYPE.RESIDENTIAL:
                return residentialTiles;
            default:
                return forestTiles;
        }
    }
}
