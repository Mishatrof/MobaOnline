using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public Animator Anim;
    public float time = 10;
    public bool isCamera;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        if (isCamera)
            Destroy(Anim, time);
        else
            Destroy(gameObject, time);
    }
}
