using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field {

    private int type;
    // private effects
    private bool isBase;

    public Field(int type) {
        this.type = type;
    }
}

public static class FIELDTYPE {
    public const int WILD = 0;
}
