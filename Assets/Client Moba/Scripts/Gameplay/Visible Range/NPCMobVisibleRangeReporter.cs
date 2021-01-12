using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPCVisibleRange))]
public class NPCMobVisibleRangeReporter : MonoBehaviour
{
    NPCVisibleRange m_VisibleRange;
    Transform m_PrewTarget;
    // Start is called before the first frame update

    void Awake()
    {
        m_VisibleRange = GetComponent<NPCVisibleRange>();
        m_PrewTarget = null;
    }

    void FixedUpdate()
    {
        var visibleTargets = m_VisibleRange.targest;

        if (visibleTargets.Count > 0 && m_PrewTarget != visibleTargets[0])
        {
            m_PrewTarget = visibleTargets[0];
            gameObject.SendMessage("OnNewTarget", m_PrewTarget, SendMessageOptions.DontRequireReceiver);
            print("OnNewTarget");
        }
        else if (visibleTargets.Count == 0 && m_PrewTarget != null)
        {
            m_PrewTarget = null;
            gameObject.SendMessage("OnLostTarget");
            print("OnLostTarget");
        }
    }
}
