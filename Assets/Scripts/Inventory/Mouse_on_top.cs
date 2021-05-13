using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mouse_on_top : MonoBehaviour
{
    public GameObject slotSelected;
    private bool visible = false;

    private void Update()
    {
        //Think
        if (IsMouseOverUIWithIgnores()) { visible = true; }

        else { visible = false; }
        
        //Act
        if (visible) { slotSelected.GetComponent<Image>().color = new Color32(255, 255, 255, 255); }

        else { slotSelected.GetComponent<Image>().color = new Color32(255, 255, 255, 0); }
    }

    private bool IsMouseOverUIWithIgnores()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);
        for (int i = 0; i < raycastResultList.Count; i++)
        {
            if (raycastResultList[i].gameObject.GetComponent<MouseUIClickthrough>() != null)
            {
                raycastResultList.RemoveAt(i);
                i--;
            }
        }

        return raycastResultList.Count > 0;
    }
}
