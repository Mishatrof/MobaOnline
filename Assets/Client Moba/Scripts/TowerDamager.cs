using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Photon.Pun;


public class TowerDamager : Damager
{
    protected override void OnEndStateAttackServer()
    { }

    protected override void OnStartStateAttackServer()
    { }

    protected override void OnStayDamage(HealthComponent mobHealth)
    { }
}
