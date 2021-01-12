using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Team))]
public class NPCTowerNetController : MonoBehaviour, INPCVisibleRangeFilter
{
    Team m_Team;


    void Awake()
    {
        m_Team = GetComponent<Team>();
    }


    bool INPCVisibleRangeFilter.Execute(Rigidbody target)
    {
        var otherTeam = target.GetComponent<Team>();
        return otherTeam != null && otherTeam.data != m_Team.data;
    }

    void OnDie()
    {
        if(PhotonNetwork.IsMasterClient)
            PhotonNetwork.Destroy(gameObject);
    }
}
