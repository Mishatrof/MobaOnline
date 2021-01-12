using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    public List<Collider> colliders;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        colliders.Add(other);
    }


    void OnTriggerStay()
    {
        print(colliders.Count);
    }

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        print(colliders.Remove(other));
    }
}
