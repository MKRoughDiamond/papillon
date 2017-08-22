using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FIELDTYPE에 따른 드롭 아이템과 관련한 데이터베이스 클래스
/// </summary>
public class FieldDropDatabase : MonoBehaviour {

    private static List<FieldDropDatabaseElement> forest;
    private static List<FieldDropDatabaseElement> ice;
    private static List<FieldDropDatabaseElement> desert;

    // 데이터베이스 규모가 커지면 다른 데이터베이스처럼 FILE I/O로 처리해도 될텐데, 일단은 크기가 작으니 스크립트 내에서 처리.
    public static void init() {
        initForest();
    }

    // load drop element list according to field type
    public static List<FieldDropDatabaseElement> load(int type) {
        switch (type) {
            case FIELDTYPE.FOREST:
                return forest;
            case FIELDTYPE.ICE:
                return ice;
            case FIELDTYPE.DESERT:
                return desert;
            default:
                return forest;
        }
    }

    private static void initForest() {
        forest = new List<FieldDropDatabaseElement>();

        forest.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("원목"), 1, 3, 0, 3));
        forest.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("돌맹이"), 1, 3, 0, 3));
        forest.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("과일"), 1, 1, 0, 2));
    }
}

public class FieldDropDatabaseElement {

    public int id;                  // item ID
    public int minItemCount;        // min item count per itemHolder
    public int maxItemCount;        // max item count per itemHolder
    public int minObjectCount;      // min itemHolder count
    public int maxObjectCount;      // max itemHolder count

    public FieldDropDatabaseElement(int id, int minItemCount, int maxItemCount, int minObjectCount, int maxObjectCount) {
        this.id = id;
        this.minItemCount = minItemCount;
        this.maxItemCount = maxItemCount;
        this.minObjectCount = minObjectCount;
        this.maxObjectCount = maxObjectCount;
    }
}
