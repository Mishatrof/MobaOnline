using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Health : MonoBehaviour
{
    public float HP = 700;

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
            Destroy(gameObject);
    }
   
  public  void TakeDamage(float dmg)
    {
        HP -= dmg;  
    }
}
