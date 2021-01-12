using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform GetParentCasernes(int idTeam)
    {
        var teamGameObjects = GameObject.Find("Level/Teamsdata").transform;
        var casernes = teamGameObjects.GetChild(idTeam).Find("Casernes");
        return casernes;
    }


    [ContextMenu("Create Template")]
    void CreateTemplate()
    {
        int countTeams = 2;

        //var level = new GameObject("Level").transform;
        var teamGO = new GameObject("Teamsdata").transform;
        //teamGO.SetParent(level);

        for(int i = 0; i < countTeams; i++)
        {
            var team = new GameObject($"Team_{i+1}").transform;
            var casernes = new GameObject("Casernes").transform;

            team.SetParent(teamGO);
            casernes.SetParent(team);
        }
    }
}
