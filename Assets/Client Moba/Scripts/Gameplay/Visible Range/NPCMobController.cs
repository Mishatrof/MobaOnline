using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NPCPursuerOfTarget))]
[RequireComponent(typeof(NavMeshAgent))]
public class NPCMobController : MonoBehaviour, IMobController
{
    public Transform targetPoint;
    NavMeshAgent m_NavAgent;
    NPCPursuerOfTarget m_PursuerOfTarget;
    // Start is called before the first frame update
    void Awake()
    {
        m_PursuerOfTarget = GetComponent<NPCPursuerOfTarget>();
        m_NavAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        if (targetPoint)
            m_NavAgent.SetDestination(targetPoint.position);
    }


    void OnNewTarget(Transform target)
    {
        m_PursuerOfTarget.StartPursuit(target);
    }

    void OnLostTarget()
    {
        m_PursuerOfTarget.StopPursuit();
        m_NavAgent.SetDestination(targetPoint.position);
    }

    void OnDie()
    {
        Destroy(gameObject);
    }

    void IMobController.Destroy()
    {
        Destroy(gameObject);
    }
}
