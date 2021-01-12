using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    int h = 3;
    // Start is called before the first frame update
    void OnAttack()
    {
        print("Ааа нас атакуют");
        if (--h <= 0)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
