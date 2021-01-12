using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCPursuerOfTarget : MonoBehaviour
{
    // можно оптимизировать
    // SetDistination вынести в корутину

    //Transform m_PursiutTarget = null;
    NavMeshAgent m_NavAgent;
    //NPCVisibleRange m_VisibleRange;
    Coroutine m_PursuitOfTargetHandler;

 
    


    public void StartPursuit(Transform target)
    {
        m_PursuitOfTargetHandler = StartCoroutine(PursuitOfTargetHandler(target));
    }

    public void StopPursuit(bool resetPath = false)
    {
        StopCoroutine(m_PursuitOfTargetHandler);

        if (resetPath)
            m_NavAgent.ResetPath();
    }


    void Awake()
    {
        m_NavAgent = GetComponent<NavMeshAgent>();
    }

    IEnumerator PursuitOfTargetHandler(Transform target)
    {
        while(target != null)
        {
            m_NavAgent.SetDestination(target.position);
            yield return new WaitForSeconds(0.4f);
        }
    }
}
