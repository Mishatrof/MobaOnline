using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBechaviour : MonoBehaviour
{
    void OnMove(Vector3 vector)
    {
        transform.Translate(vector);

        throw new System.Exception();
    }
}
