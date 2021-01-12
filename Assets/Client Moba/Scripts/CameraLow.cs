using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class CameraLow : MonoBehaviour
    {
        public MineTeamComponent m_MineTeam;
        public Transform m_PosTeamA;
        public Transform m_PosTeamB;


        void Start()
        {
            UpdatePosition();
        }


        public void UpdatePosition()
        {
            switch(m_MineTeam.teamId)
            {
                case 0:
                    transform.position = m_PosTeamA.position;
                    transform.rotation = m_PosTeamA.rotation;
                    break;
                case 1:
                    transform.position = m_PosTeamB.position;
                    transform.rotation = m_PosTeamB.rotation;
                    break;

            }
        }
    }
}
