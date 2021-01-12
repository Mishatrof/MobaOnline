using MyAsset;
using SimpleFogOfWar;
using UnityEngine;

public class UnitFogOfWarSystem : MonoBehaviour, IListener<GameObject>
{
    public GameObjectEvent m_OnNewUnit;
    public MineTeamComponent m_MineTeamComponent;

    void OnEnable() { m_OnNewUnit.AddListener(this); }

    void OnDisable() { m_OnNewUnit.RemoveListener(this); }

    void Start()
    {
        foreach (var fogScript in FindObjectsOfType<FogOfWarInfluence>())
            if (fogScript.TryGetComponent(out Team teamComponent))
                fogScript.enabled = m_MineTeamComponent.teamId == teamComponent.teamId;
    }

    void IListener<GameObject>.OnInvoke(GameObject unit)
    {
        var fogScript = unit.GetComponent<FogOfWarInfluence>();
        var teamComponent = unit.GetComponent<Team>();

        fogScript.enabled = m_MineTeamComponent.teamId == teamComponent.teamId;
    }
}
