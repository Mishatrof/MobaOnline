using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_Mobs : MonoBehaviour
{

    public GameObject[] objs; // массив героев
    public Text textName;

    public void NewObj(int index)
    {
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].SetActive(false);
           
        }
        objs[index].SetActive(true);
        TakeInfo(index);
    }

    public void TakeInfo(int index)
    {
        textName.text = objs[index].name;
    }
    
}
