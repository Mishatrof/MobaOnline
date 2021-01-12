using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyAsset;

public class UnitTeamInitSystem : MonoBehaviour, IListener<GameObject>
{
    public GameObjectEvent m_OnNewUnit;
    public TeamDataList m_TeamList;

    void OnEnable() { m_OnNewUnit.AddListener(this); }

    void OnDisable() { m_OnNewUnit.RemoveListener(this); }

    void IListener<GameObject>.OnInvoke(GameObject unit)
    {
        var teamComponent = unit.GetComponent<Team>();

        teamComponent.data = m_TeamList.GetTeam(teamComponent.teamId);
    }
}
