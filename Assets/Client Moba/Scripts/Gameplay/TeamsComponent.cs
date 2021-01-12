using RPGGame.GameBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamsComponent : MonoBehaviour
{
    public int mineTeamId;
    public List<TeamSceneData> m_TeamsConfig = null;

    public TeamSceneData mineTeam => m_TeamsConfig[mineTeamId];
}

[System.Serializable]
public class TeamSceneData
{
    public string Name;
    public Transform SpawnPointSuperHero;
    public GameObject PrefabSuperHero;
    public int experience;
    public int level;
    public GameObject dataObject;
    //public GameBase[] casernes;

    [Header("Debug")]
    public bool isSync;
}
