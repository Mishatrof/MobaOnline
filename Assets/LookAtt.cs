using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtt : MonoBehaviour
{

    public Transform Cam;

    // Start is called before the first frame update
    void Start()
    {
        Cam = GameObject.Find("Main Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Cam);
    }
}
