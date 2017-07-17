using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchManager : MonoBehaviour {

    GameManager gm;

    List<Technology> lockedList;
    List<Technology> availableList;
    List<Technology> doneList;

    private void Awake() {
        gm = GameManager.gm;
        lockedList = new List<Technology>();
        availableList = new List<Technology>();
        doneList = new List<Technology>();

    }

    public void researchInit() {
        List<Technology> lockedList = TechnologyDatabase.load();

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
        for(int i = 0; i < availableList.Count; i++) {

            // according technology found
            if (availableList[i].getID() == id) {

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
    }

    // update technologies' requirements
    private void spreadResearchDone(int id) {
        for(int i=lockedList.Count-1; i>=0; i++) {

            // update
            lockedList[i].updateRequirements(id);

            // if all requirements satisfied, move it to available
            if (lockedList[i].Satisfied()) {
                availableList.Add(lockedList[i]);
                lockedList.RemoveAt(i);
            }
        }
    }
}
