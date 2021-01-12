using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Photon.Pun;

public enum SuperHeroStates
{
    Action, Die
}

[RequireComponent(typeof(NPCPursuerOfTarget))]
[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(NavMeshAgent))]
public class NPCSuperHeroNetwork : MonoBehaviour, INPCVisibleRangeFilter
{
    public int teamId;
    public Helper helper;
    public event System.Action onDie;

    NavMeshAgent m_NavAgent;
    NPCPursuerOfTarget m_PursuerOfTarget;
    PhotonView m_PhotonView;
    Team m_Team;
    NPCVisibleRangeFirstTarget visibleRange;
    Collider[] selfColliders;

    float resurrectionTime;

    enum States
    { None, Idle, Seek, Die }

    States state;


    void Awake()
    {
#if UNITY_EDITOR
        if (!PhotonNetwork.IsConnectedAndReady)
        {
            var controller = gameObject.AddComponent<NPCMobController>();
            Destroy(this);
            return;
        }
#endif
        visibleRange = GetComponent<NPCVisibleRangeFirstTarget>();
        selfColliders = GetComponentsInChildren<Collider>();
        m_PursuerOfTarget = GetComponent<NPCPursuerOfTarget>();
        m_NavAgent = GetComponent<NavMeshAgent>();
        m_PhotonView = GetComponent<PhotonView>();
        m_Team = GetComponent<Team>();
    }

    void Update()
    {
        //var newState = States.None;

        switch(state)
        {
            case States.Idle:
                visibleRange.enabled = false;
                // seek target
                break;

            case States.Seek:
                // if target_health == 0
                //      visibleRange.enabled = true
                break;

            case States.Die:
                resurrectionTime += Time.deltaTime;

                if (resurrectionTime > 15f)
                {
                    foreach (var collider in selfColliders)
                        collider.enabled = true;

                    visibleRange.enabled = true;
                    state = States.Idle;
                }
                break;
        }
    }


    
    void OnNewTarget(Transform target)
    {
        m_PursuerOfTarget.StartPursuit(target);
    }

    void OnLostTarget()
    {
    }

    void OnDie()
    {
        onDie?.Invoke();

        //GetComponentInChildren<Animator>().SetTrigger("die");

        visibleRange.enabled = false;
        state = States.Die;
        m_NavAgent.ResetPath();

        foreach (var collider in selfColliders)
            collider.enabled = false;



        if (PhotonNetwork.IsMasterClient)
        {
            SendMessage("OnRespawn");
        }
        //{
        //    m_PhotonView.RPC("SetPosition", RpcTarget.All, Vector3.zero);

            //}
            //    m_PhotonView.RPC("SetAvtive", RpcTarget.Others, false);
    }

    public void NetSetDistination(Vector3 destination)
    {
        m_PhotonView.RPC("SetDistination", RpcTarget.Others, destination);
        SetDistination(destination);
    }

    void NetSetPursuitTarget(Transform target)
    {
        var targetPhotonView = target.GetComponent<PhotonView>();
        m_PhotonView.RPC("SetPursuitTarget", RpcTarget.Others, targetPhotonView.ViewID);
        m_PursuerOfTarget.StartPursuit(target);
    }

    [PunRPC]
    void SetDistination(Vector3 destination)
    {
        m_NavAgent.SetDestination(destination);
    }

    [PunRPC]
    void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }

    [PunRPC]
    void SetPursuitTarget(int idTarget)
    {
        var target = PhotonNetwork.GetPhotonView(idTarget);
        

        if (target != null)
            m_PursuerOfTarget.StartPursuit(target.transform);
    }

    bool INPCVisibleRangeFilter.Execute(Rigidbody target)
    {
        var otherTeam = target.GetComponent<Team>();
        return otherTeam != null && otherTeam.data != m_Team.data;
    }
   //void Update()
   // {
   //     helper = GameObject.FindObjectOfType<Helper>();
   //     helper.UpdateHp();
   // }
}
