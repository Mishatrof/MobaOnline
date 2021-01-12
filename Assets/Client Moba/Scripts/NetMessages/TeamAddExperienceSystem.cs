using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;

namespace StaticSystems
{
    public struct TeamAddExperience
    {
        public int teamId;
        public int experience;
    }

    public class TeamAddExperienceSystem : StaticUnitySystem<TeamAddExperience>
    {
        public TeamsComponent teamsComponent;

        protected override void Run(List<TeamAddExperience> dataList)
        {
            if (PhotonNetwork.IsMasterClient == false)
                return;

            

            foreach (var item in dataList)
            {
                var teamStats = teamsComponent.m_TeamsConfig[item.teamId];

                print(item.teamId +" " + item.experience);

                teamStats.experience += item.experience;
                teamStats.isSync = false;
            }
        }

        static public void Add(int teamId, int upValue)
        {
            Add(new TeamAddExperience { teamId = teamId, experience = upValue });
        }
    }
}
