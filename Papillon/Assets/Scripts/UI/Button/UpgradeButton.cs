using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour {

    public int upgradeType;

    private Base baseObject;

    private void Start() {
        baseObject = GameManager.gm.getBoardManager().getBase();

        // if no more upgrade is possible
        if (!baseObject.canUpgradeBase(upgradeType)) {
            gameObject.SetActive(false);
        }
    }

    public void onClick() {
        baseObject.upgradeBase(upgradeType);
    }
}
