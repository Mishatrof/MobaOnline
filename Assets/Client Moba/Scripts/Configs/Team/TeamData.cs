using MyAsset;
using System.Collections.Generic;
using UnityEngine;
using RPGGame.GameBase;

[CreateAssetMenu]
public class TeamData : ScriptableObject
{
    [SerializeField]
    public GameObject m_DefaultMob;

    public GameObject m_SuperHero;

    //public TeamRuntimeData runtimeData = new TeamRuntimeData();

    public int money { set; get; }
    public Dictionary<int, GameBase> casernes { private set; get; }


    public TeamData()
    {
        casernes = new Dictionary<int, GameBase>();
    }

    #region Public Methods
    public void Init()
    {
        money = 500;
        Debug.Log("init");
    }


    //public void AddBase(GameBase gameBase, int index)
    //{
    //    m_GameBases.Add(index, gameBase);
    //}

    //public void RemoveBase(int index)
    //{
    //    m_GameBases.Remove(index);
    //}

    //public GameBase GetBase(int index)
    //{
    //    return m_GameBases[index];
    //}
    #endregion

}
