using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyAsset;

[CreateAssetMenu]
public class InitLocalMobsList : ScriptableObject
{
    public GameObjectList m_MobsListTeamA;
    public GameObjectList m_MobsListTeamB;
    public GameObjectList m_LocalMobsList;

    public void Distribute()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            m_LocalMobsList.list = new List<GameObject>(m_MobsListTeamA.list);
        }
        else
        {
            m_LocalMobsList.list = new List<GameObject>(m_MobsListTeamB.list);
        }
    }
}
