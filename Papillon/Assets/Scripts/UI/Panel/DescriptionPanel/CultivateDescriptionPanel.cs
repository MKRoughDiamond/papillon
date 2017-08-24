using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CultivateDescriptionPanel : DescriptionPanel {

    public Text name;
    public Text description;

    private CultivateElement e;

    public override void setDescriptee(GameObject descriptee) {
        e = descriptee.GetComponent<CultivatePanelElement>().getElement();

        Item product = ItemDatabase.findItem(e.getProductId());
        name.text = product.getName();
        description.text = product.getDescription();
    }
}
