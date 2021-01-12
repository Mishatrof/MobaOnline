using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Photon.Pun;
using MyAsset;

namespace Client.Game
{
    public enum MobState { None, WalkToDestination, PursuerTarget } 

    [RequireComponent(typeof(NPCPursuerOfTarget))]
    [RequireComponent(typeof(PhotonView))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class NPCMobNetwork : MonoBehaviour, INPCVisibleRangeFilter, IPunInstantiateMagicCallback
    {
        public Transform targetPoint;
        public Animator Anim;

        MobState debugState;


        NavMeshAgent m_NavAgent;
        NPCPursuerOfTarget m_PursuerOfTarget;
        PhotonView m_PhotonView;
        Team m_Team;

        void IPunInstantiateMagicCallback.OnPhotonInstantiate(PhotonMessageInfo info)
        {
            object[] data = info.photonView.InstantiationData;
            int team = (byte)data[0];

            m_Team.teamId = team;

            if (GameManager.mineTeamId == team) gameObject.AddComponent<LineTriggerAgent>();
        }


        void Awake()
        {
#if UNITY_EDITOR
            if (!PhotonNetwork.IsConnectedAndReady)
            {
                var controller = gameObject.AddComponent<NPCMobController>();
                controller.targetPoint = targetPoint;
                Destroy(this);
                return;
            }
#endif

            m_PursuerOfTarget = GetComponent<NPCPursuerOfTarget>();
            m_NavAgent = GetComponent<NavMeshAgent>();
            m_PhotonView = GetComponent<PhotonView>();
            m_Team = GetComponent<Team>();
            debugState = MobState.None;
        }

        void Start()
        {
            if (targetPoint == null)
                Debug.LogError("not set target point");

            if (PhotonNetwork.IsMasterClient)
                NetSetDistination(targetPoint.position);

            //if (!PhotonNetwork.IsConnectedAndReady)
            //    m_OnNewUnit.Raise(gameObject);
        }


        void OnNewTarget(Transform target)
        {
            m_PursuerOfTarget.StartPursuit(target);
            debugState = MobState.PursuerTarget;
            //if (PhotonNetwork.IsMasterClient)
            //    NetSetPursuitTarget(target);
        }

        void OnLostTarget()
        {
            if (PhotonNetwork.IsMasterClient)
                NetSetDistination(targetPoint.position);
        }

        void OnDie()
        {
            if (PhotonNetwork.IsMasterClient)
                PhotonNetwork.Destroy(gameObject);
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
            Anim.SetBool("Go", true);
            debugState = MobState.WalkToDestination;
        }

        [PunRPC]
        void SetPursuitTarget(int idTarget)
        {
            var target = PhotonNetwork.GetPhotonView(idTarget).transform;
            m_PursuerOfTarget.StartPursuit(target);
            debugState = MobState.PursuerTarget;
        }



        bool INPCVisibleRangeFilter.Execute(Rigidbody target)
        {
            var otherTeam = target.GetComponent<Team>();
            return otherTeam != null && otherTeam.data != m_Team.data;
        }


    }
}