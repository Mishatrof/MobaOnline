using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
public class RightClip : MonoBehaviour, IPointerClickHandler
{

    public GameObject BuyPanel;
    public void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Right)
            BuyPanel.SetActive(true);
    }
}
