using MyAsset;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthGameBase : HealthComponent
{
    [SerializeField]
    private GameObjectEvent m_OnDied;

    public override void SetDamage(int damage)
    {
        base.SetDamage(damage);

        if (isDied)
        {
            m_OnDied.Raise(gameObject);
        }
    }
}
