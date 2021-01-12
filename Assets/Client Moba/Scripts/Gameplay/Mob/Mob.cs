using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(NavMeshAgent))]
public class Mob : MonoBehaviourPun
{
    public NavMeshAgent agent { get; private set; }

    public bool GG;

    public void SetDestination(Vector3 position)
    {
        if (PhotonNetwork.IsMasterClient)
            photonView.RPC("OnSetDestinationRPC", RpcTarget.All, position);
    }



    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    

    // Start is called before the first frame update
    //void Start()
    //{
    //}

    // Update is called once per frame
    //void FixedUpdate()
    //{
    //    if (!photonView.IsMine)
    //        return;

    //    if (Vector3.Distance(m_Agent.pathEndPosition, transform.position) < m_Agent.stoppingDistance)
    //    {
    //        PhotonNetwork.Destroy(gameObject);
    //    }
    //}


    [PunRPC]
    private void OnSetDestinationRPC(Vector3 position)
    {
        agent.SetDestination(position);
    }
}
