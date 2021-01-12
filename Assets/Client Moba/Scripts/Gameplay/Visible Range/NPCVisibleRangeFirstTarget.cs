using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.AI;
using Photon.Pun;

//public enum StateVisibleRange
//{
//    New, Lost, See, Search
//}

public class NPCVisibleRangeFirstTarget : MonoBehaviour
{
    static WaitForSeconds periodUpdate = new WaitForSeconds(0.3f);
    // Выбор первой попавшей 
    // цели в зону видимости

    public float m_Radius;
    public LayerMask m_LifeLayer;

    //public bool isSeeTarget => m_ActiveRigidbody != null;
    public int targetNetId { private set; get; }

    Rigidbody m_Rigidbody;
    Rigidbody m_ActiveRigidbody;
    INPCVisibleRangeFilter m_Filter;
    PhotonView photonView;

    Collider[] targets;
    bool state;

    void Awake()
    {
        targets = new Collider[16];
        m_ActiveRigidbody = null;
        m_Filter = GetComponent<INPCVisibleRangeFilter>();
        m_Rigidbody = GetComponent<Rigidbody>();
        photonView = GetComponent<PhotonView>();
    }

    void OnEnable()
    {
        if (!PhotonNetwork.IsMasterClient) {
            enabled = false;
            return;
        }

        StartCoroutine(SearchVisibleTargetHandler());
    }

    void OnDisable()
    {
        StopAllCoroutines();

        m_ActiveRigidbody = null;
        targetNetId = -1;
        SendMessageLostTarget();
    }

    void Step()
    {
        bool newState = m_ActiveRigidbody != null && m_ActiveRigidbody.gameObject.activeSelf;
        bool shouldSearch = false;

        if (state)
        {
            if (newState) {
                Vector3 position = transform.position;
                Vector3 closestPoint = m_ActiveRigidbody.ClosestPointOnBounds(position);

                if (Vector3.Distance(position, closestPoint) > m_Radius)
                    shouldSearch = true;
            } else {
                shouldSearch = true;
            }
        } else {
            shouldSearch = true;
        }

        if(shouldSearch)
        {
            if (SearchTarget()) {
                SendMessageNewTarget();
                state = true;
            } else if (state) {
                SendMessageLostTarget();
                state = false;
            }
        }
    }

    IEnumerator SearchVisibleTargetHandler()
    {
        // Может сработать перед тем как инициализируется контроллер
        // Поэтому пропускаем один кадр
        yield return null;

        while (true)  {
            Step();
            yield return periodUpdate;
        }
    }

    bool SearchTarget()
    {
        var colliderCount = Physics.OverlapSphereNonAlloc(transform.position, m_Radius, targets, m_LifeLayer, QueryTriggerInteraction.Collide);
        m_ActiveRigidbody = null;

        for (int i = 0; i < colliderCount; i++)
        {
            var otherRigidbody = targets[i].attachedRigidbody;

            if (ValidateTarget(otherRigidbody) && otherRigidbody.TryGetComponent(out PhotonView photonView))
            {
                targetNetId = photonView.ViewID;
                m_ActiveRigidbody = otherRigidbody;
                return true;
            }
        }

        return false;
    }


    bool ValidateTarget(Rigidbody target)
    {
        return !(target == m_Rigidbody || target == null ||
            m_Filter != null && !m_Filter.Execute(target));
    }


    void SendMessageNewTarget()
    {
        photonView.RPC("AcceptMsgNewTarget", RpcTarget.All, targetNetId);
    }

    void SendMessageLostTarget()
    {
        //photonView.RPC("AcceptMsgLostTarget", RpcTarget.All);
        // пока не используется клиентом
        AcceptMsgLostTarget();
    }


    [PunRPC]
    void AcceptMsgNewTarget(int netid)
    {
        var targetView = PhotonNetwork.GetPhotonView(netid);

        if (targetView != null)
        {
            SendMessage("OnNewTarget", targetView.transform,
                SendMessageOptions.DontRequireReceiver);
        }
    }

    [PunRPC]
    void AcceptMsgLostTarget()
    {
        SendMessage("OnLostTarget", SendMessageOptions.DontRequireReceiver);
    }

    


    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 1f, 1f, 0.3f);
        Gizmos.DrawWireSphere(transform.position, m_Radius);

        if (m_ActiveRigidbody != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, m_ActiveRigidbody.position);
        }
    }
}
