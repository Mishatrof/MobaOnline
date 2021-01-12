using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStringHash : MonoBehaviour
{
    public string str1;
    public string str2;
    public string str3;

    public bool printHash;

    public void OnValidate()
    {
        if (!printHash)
            return;

        printHash = false;

        string pstr = string.Empty;

        pstr += $"{nameof(str1)}={str1.GetHashCode()}\n";
        pstr += $"{nameof(str2)}={str2.GetHashCode()}\n";
        pstr += $"{nameof(str3)}={str3.GetHashCode()}";

        Debug.Log(pstr);
    }
}
