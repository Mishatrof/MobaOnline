using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobComponent : MonoBehaviour
{
    public int damage = 10;
    public float deltaHit = 1f;

    public int health = 100;

    public float visibleRange = 4f;

    public TeamData team;
    public NavMeshAgent navAgent;

    
}
