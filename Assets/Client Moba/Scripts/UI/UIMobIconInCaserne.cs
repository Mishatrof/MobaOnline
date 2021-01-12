using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMobIconInCaserne : MonoBehaviour
{
    public void UpdateCells(List<Sprite> colorList)
    {
        for (int i = 0; i < colorList.Count; i++)
            transform.GetChild(i).GetComponent<Image>().sprite = colorList[i];
    }
}
