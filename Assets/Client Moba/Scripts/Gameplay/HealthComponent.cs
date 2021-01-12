using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviourPun
{
    [SerializeField]
    private int m_Health = 100;


    public int health { set { m_Health = value; } get { return m_Health; } }
    public bool isDied => m_Health <= 0;


    public virtual void SetDamage(int damage)
    {
        m_Health -= damage;

        if (isDied)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
