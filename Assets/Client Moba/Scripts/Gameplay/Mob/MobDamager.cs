using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Mob))]
public class MobDamager : Damager
{
    private Mob m_Mob;

    private Vector3 m_PrewDestinationAgent;


    public void UpdateArmys()
    {
       
        //m_Damage = 15;
    }


    protected new void Start()
    {
       

        base.Start();

        m_Mob = GetComponent<Mob>();
        m_PrewDestinationAgent = Vector3.zero;
    }

    protected override void OnEndStateAttackServer()
    {
        m_Mob.SetDestination(m_PrewDestinationAgent);
    }

    protected override void OnStartStateAttackServer()
    {
        m_PrewDestinationAgent = m_Mob.agent.destination;
    }

    protected override void OnStayDamage(HealthComponent mobHealth)
    {
        m_Mob.agent.SetDestination(mobHealth.transform.position);
    }
}
