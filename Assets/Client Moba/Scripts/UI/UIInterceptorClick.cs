using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInterceptorClick : MonoBehaviour, IPointerClickHandler
{
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        foreach (Transform child in transform)
            if(child.TryGetComponent(out IPointerClickHandler handler))
                handler.OnPointerClick(eventData);
    }
}
