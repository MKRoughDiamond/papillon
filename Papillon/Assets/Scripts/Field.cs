using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field {

    private int type;
    // private effects
    private bool isBase;

    List<ItemHolder> droppeditems;

    public Field(int type) {
        this.type = type;
        switch (this.type)
        {
            case FIELDTYPE.WILD:
                int times = (int)Random.Range(10,20);
                for (int i = 0; i < times; i++)
                {
                    
                }
                break;
            default:
                break;
        }
    }
}

public static class FIELDTYPE {
    public const int WILD = 0;
}