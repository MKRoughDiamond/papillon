using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Technology : MonoBehaviour {

    public int id;                      // Unique ID of tech
    public string name;                 // name of tech
    public string description;          // Tech description
    public List<Requirement> requirements;   // Tech requirements <requirement, done>
    public int researchPoint;           // point for research done
    public int currentPoint;            // current point

    private bool isDone;                 // Technology research Done Check
    private bool isSatisfied;            // Technology requirements Done Check
    private Texture2D icon;


    public Technology(int id, string name, string description, int researchPoint, List<int> requirements) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.researchPoint = researchPoint;
        this.currentPoint = 0;

        this.requirements = new List<Requirement>();
        foreach(int r in requirements) {
            this.requirements.Add(new Requirement(r));
        }

        LoadIcon();
    }

    private void LoadIcon() {
        // TODO: icon load
    }

    public int getId() {
        return id;
    }

    public string getName() {
        return name;
    }

    public string getDescription() {
        return description;
    }

    public int getCurrentPoint() {
        return currentPoint;
    }

    public int getResearchPoint() {
        return researchPoint;
    }


    // progress technology research
    public bool progress(int point) {
        if (Satisfied() && !Done()) {
            currentPoint += point;
            return true;
        } else
            return false;
    }

    // check if technology research is done
    public bool Done() {
        if (isDone)
            return true;
        else if (researchPoint <= currentPoint) {
            isDone = true;
            return true;
        } else
            return false;
    }

    // check if technology research is possible
    public bool Satisfied() {
        return isSatisfied || RequirementsDone();
    }

    // update technology requirements satisfaction
    public void updateRequirements(int id) {
        for(int i = 0; i < requirements.Count; i++) {
            if(requirements[i].tech.getId() == id) {
                requirements[i].done = true;
                return;
            }
        }
    }

    // check if all requirements are done
    private bool RequirementsDone() {

        foreach (Requirement r in requirements) {
            if(!r.done) {
                return false;
            }
        }

        isSatisfied = true;
        return true;
    }

}

public class Requirement {
    //public int id;
    public Technology tech;
    public bool done;

    public Requirement(int id) {
        this.tech = TechnologyDatabase.findTechnology(id);
        this.done = false;
    }

    public Requirement(int id, bool done) {
        this.tech = TechnologyDatabase.findTechnology(id);
        this.done = done;
    }
}
