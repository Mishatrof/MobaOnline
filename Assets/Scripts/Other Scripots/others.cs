using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class others : MonoBehaviour
{
    public void Back(GameObject _obj)
    {
        _obj.SetActive(false);
    }
    public void Open(GameObject _obj)
    {
        _obj.SetActive(true);
    }
}
