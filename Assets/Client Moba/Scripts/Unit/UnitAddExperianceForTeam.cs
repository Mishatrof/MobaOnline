using Photon.Pun;
using StaticSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Team))]
public class UnitAddExperianceForTeam : MonoBehaviour
{
    void OnTargetKill()
    {
        print("OnTargetKill");

        if (PhotonNetwork.IsMasterClient)
        {
            var team = GetComponent<Team>();
            TeamAddExperienceSystem.Add(team.teamId, 25);
        }
    }
}
