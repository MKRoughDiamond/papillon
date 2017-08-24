using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FIELDTYPE에 따른 드롭 아이템과 관련한 데이터베이스 클래스
/// </summary>
public class FieldDropDatabase : MonoBehaviour {

    private static List<FieldDropDatabaseElement> forest;
    private static List<FieldDropDatabaseElement> residential;
    private static List<FieldDropDatabaseElement> factory;
    private static List<FieldDropDatabaseElement> rocket;

    // 데이터베이스 규모가 커지면 다른 데이터베이스처럼 FILE I/O로 처리해도 될텐데, 일단은 크기가 작으니 스크립트 내에서 처리.
    public static void init() {
        initForest();
        initRocket();
        initResidential();
        initFactory();
    }

    // load drop element list according to field type
    public static List<FieldDropDatabaseElement> load(int type) {
        switch (type) {
            case FIELDTYPE.FOREST:
                return forest;
            case FIELDTYPE.RESIDENTIAL:
                return residential;
            case FIELDTYPE.FACTORY:
                return factory;
            case FIELDTYPE.ROCKET:
                return rocket;
            default:
                return forest;
        }
    }

    private static void initForest() {
        forest = new List<FieldDropDatabaseElement>();

        forest.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("원목"), 1, 3, 2, 6));
        forest.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("그린프루트"), 1, 3, 3, 9));
        forest.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("레드콘 씨앗"), 1, 1, -7, 2));
        forest.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("오렌지포테이토 씨앗"), 1, 1, -7, 2));
    }

    private static void initResidential()
    {
        residential = new List<FieldDropDatabaseElement>();

        residential.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("원목"), 1, 3, 0, 2));
        residential.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("그린프루트"), 1, 3, 0, 2));
        residential.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("벽돌"), 2, 3, 2, 6));
        residential.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("철 조각"), 1, 5, 0, 4));
        residential.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("고장난 회로"), 1, 2, -4, 2));
        residential.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("천"), 1, 5, 0, 4));
        residential.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("통조림"), 1, 1, -2, 2));
    }

    private static void initFactory()
    {
        factory = new List<FieldDropDatabaseElement>();

        factory.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("철 조각"), 2, 3, 2, 6));
        factory.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("티타늄 조각"), 1, 2, 0, 4));
        factory.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("벽돌"), 2, 3, 0, 4));
        factory.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("고장난 회로"), 1, 5, 0, 4));
        factory.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("철 주괴"), 1, 2, -7, 2));
        factory.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("티타늄 주괴"), 1, 1, -7, 2));
        factory.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("연료"), 2, 3, 2, 6));
        factory.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("우라늄 셀"), 1, 1, -19, 2));
    }

    private static void initRocket() {
        rocket = new List<FieldDropDatabaseElement>();

        rocket.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("연료 로켓 엔진"), 0, 0, 1, 1));
        rocket.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("바이오 로켓 엔진"), 0, 0, 1, 1));
        rocket.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("원자력 로켓 엔진"), 0, 0, 1, 1));
        rocket.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("우주선 날개"), 0, 0, 1, 1));
        rocket.Add(new FieldDropDatabaseElement(ItemDatabase.findIdByName("우주선 동체"), 0, 0, 1, 1));
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
