using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyAsset;

[CreateAssetMenu]
public class TeamDataList : ScriptableObject, IEnumerable<TeamData>
{
    [SerializeField]
    private List<TeamData> m_TeamsList;
    [SerializeField]
    private TeamData m_MineTeam = null;

    public int count => m_TeamsList.Count;
    public List<TeamData> list => m_TeamsList;
    public TeamData mineTeam { get { return m_MineTeam; } }


    public void SetMineTeam(Photon.Realtime.Player player)
    {
        m_MineTeam = GetTeam(player);
        Debug.Log(mineTeam.name);
    }

    public TeamData GetTeam(int index)
    {
        return m_TeamsList[index];
    }

    public TeamData GetTeam(Photon.Realtime.Player player)
    {
        if (player.CustomProperties.TryGetValue("t", out object teamIndex) && teamIndex is byte)
        {
            return m_TeamsList[(byte)teamIndex];
        }
        else
        {
            Debug.LogWarning("Not init teams");
            return m_TeamsList[0];
            //throw new System.Exception("Not key");
        }
    }

    IEnumerator<TeamData> IEnumerable<TeamData>.GetEnumerator()
    {
        return m_TeamsList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return m_TeamsList.GetEnumerator();
    }
}
