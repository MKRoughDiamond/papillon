using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultivateManager : MonoBehaviour {

    private GameManager gm;
    private Player player;
    private Base baseObject;

    public void init(Base b) {
        baseObject = b;
    }

    public List<CultivateElement> getCultivatingList() {
        return baseObject.getCultivatingList();
    }

    public List<CultivateElement> getDoneList() {
        return baseObject.getDoneList();
    }
}
