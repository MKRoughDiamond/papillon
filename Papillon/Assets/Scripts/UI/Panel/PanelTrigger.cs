using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 마우스 트리거로 인해 생성되는 (MouseDown -> open / MouseUp -> close) 패널을 생성시키는 오브젝트에 부착하는 스크립트
/// </summary>
public class PanelTrigger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public GameObject panel;
    public PointerEventData.InputButton trigger;

    private GameObject generatedPanel;

    public void OnPointerDown(PointerEventData eventData) {
        
        if(eventData.button == trigger) {
            generate();
        }
    }

    public void OnPointerUp(PointerEventData eventData) {

        if(eventData.button == trigger) {
            remove();
        }
    }

    public virtual void generate() {
        //Vector3 position = 
        Vector3 position = gameObject.transform.position + new Vector3(150, 0f, 0f);
        generatedPanel = Instantiate(panel, position, Quaternion.identity) as GameObject;
        generatedPanel.transform.SetParent(GameObject.Find("Canvas").transform);
        generatedPanel.GetComponent<DescriptionPanel>().setDescriptee(gameObject);
    }

    public virtual void remove() {
        Destroy(generatedPanel);
    }
}
