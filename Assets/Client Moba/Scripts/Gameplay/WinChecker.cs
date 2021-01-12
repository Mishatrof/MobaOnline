using MyAsset;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game
{
    public class WinChecker : MonoBehaviourPun
    {
        [SerializeField]
        private GameObjectList m_GameBasesA;
        [SerializeField]
        private GameObjectList m_GameBasesB;

        [SerializeField]
        private BoolEvent m_GameOver;


        public void OnUpdateList()
        {
            if (m_GameBasesA.Count == 0 && m_GameBasesB.Count == 0)
                photonView.RPC("OnGameOverRPC", RpcTarget.All, "");

            if(m_GameBasesA.Count == 0)
                photonView.RPC("OnGameOverRPC", RpcTarget.All, "Team B");
            if (m_GameBasesB.Count == 0)
                photonView.RPC("OnGameOverRPC", RpcTarget.All, "Team A");


        }

        [PunRPC]
        private void OnGameOverRPC(string winTeam)
        {
            m_GameOver.Raise(GameManager.localTeam.Equals(winTeam));
        }
    }
}
