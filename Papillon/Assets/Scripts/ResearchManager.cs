﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchManager : MonoBehaviour {

    GameManager gm;

    List<Technology> lockedList;
    List<Technology> availableList;
    List<Technology> doneList;

    public void init() {

        gm = GameManager.gm;

        lockedList = new List<Technology>(TechnologyDatabase.load());
        availableList = new List<Technology>();
        doneList = new List<Technology>();

        // move basic technologies to available
        for(int i = lockedList.Count-1; i>=0; i--) {
            if (lockedList[i].Satisfied()) {
                availableList.Add(lockedList[i]);
                lockedList.RemoveAt(i);
            }
        }
    }

    // progress research
    public void progress(int id, int point) {
        if (!gm.canPlayerResearch())
            return;

        for(int i = 0; i < availableList.Count; i++) {

            // according technology found
            if (availableList[i].getId() == id) {

                // update point
                availableList[i].progress(point);

                // if done
                if (availableList[i].Done()) {
                    doneList.Add(availableList[i]);
                    availableList.RemoveAt(i);

                    // update other technologies' requirements
                    spreadResearchDone(id);
                }
            }
        }

        gm.useResearchChance();
    }

    // update technologies' requirements
    private void spreadResearchDone(int id) {
        for(int i=lockedList.Count-1; i>=0; i--) {

            // update
            lockedList[i].updateRequirements(id);

            // if all requirements satisfied, move it to available
            if (lockedList[i].Satisfied()) {
                availableList.Add(lockedList[i]);
                lockedList.RemoveAt(i);
            }
        }
    }

    // check technology is done
    public bool checkTechDone(int id) {
        foreach(Technology tech in doneList) {
            if (tech.getId() == id)
                return true;
        }
        return false;
    }

    // check technology is done
    public bool checkTechDone(string name) {
        foreach (Technology tech in doneList) {
            if (tech.getName() == name)
                return true;
        }
        return false;
    }

    public List<Technology> getLockedList() {
        return lockedList;
    }

    public List<Technology> getAvailableList() {
        return availableList;
    }

    public List<Technology> getDoneList() {
        return doneList;
    }
}
