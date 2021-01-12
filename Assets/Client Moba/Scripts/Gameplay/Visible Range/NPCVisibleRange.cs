using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCVisibleRange : MonoBehaviour
{
    public float m_Radius;
    public LayerMask m_LifeLayer;

    public List<Transform> targest {
        get {
            m_VisibleTargets.RemoveAll(item => item == null);
            return m_VisibleTargets;
        }
    }

    private List<Transform> m_VisibleTargets = new List<Transform>(16);

    private const float DeltaUpdateSearchTargets = 0.5f;


    void OnEnable()
    {
        StartCoroutine(SearchTargetHandler());
    }


    IEnumerator SearchTargetHandler()
    {
        var waiter = new WaitForSeconds(DeltaUpdateSearchTargets);

        while(true)
        {
            OverlapVisibleRange();
            yield return waiter;
        }
    }


    void OverlapVisibleRange()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_Radius, m_LifeLayer);

        m_VisibleTargets.Clear();
        

        for (int i = colliders.Length - 1; i >= 0; i--)
            m_VisibleTargets.Add(colliders[i].transform);
        //foreach (var target in colliders)
        //    m_VisibleTargets.Add(target.transform);
    }


    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, m_Radius);
    }
}
