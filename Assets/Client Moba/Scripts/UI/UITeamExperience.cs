using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITeamExperience : MonoBehaviour
{
    public MineTeamComponent mineTeamComponent;
    public TeamsComponent teamsComponent;


    void OnGUI()
    {
        var exp = teamsComponent.m_TeamsConfig[mineTeamComponent.teamId].experience;
        var lvl = teamsComponent.m_TeamsConfig[mineTeamComponent.teamId].level;

        GUILayout.BeginArea(new Rect(10, 50, 100, 50));
        GUILayout.Label($"Experience {exp}");
        GUILayout.Label($"Level {lvl}");
        GUILayout.EndArea();
    }
}
