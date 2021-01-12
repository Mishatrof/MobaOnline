using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum SuperHeroMessages
{
    SetDistination, SetTarget, 
}

public class SuperHeroClient : MonoBehaviour
{
    NPCPursuerOfTarget seekBehaviour;
    NavMeshAgent navAgent;

    public const byte setDistination = 1;
    

    [PunRPC]
    protected virtual void OnSetDistination(Vector3 value)
    {
        navAgent.SetDestination(value);
    }

    [PunRPC]
    protected virtual void OnSetTarget(int id)
    {
        var photonView = PhotonNetwork.GetPhotonView(id);

        if (photonView != null)
        {
            seekBehaviour.StartPursuit(photonView.transform);
        }
    }

    [PunRPC]
    protected virtual void OnDie()
    {
        Destroy(gameObject);
    }
}
