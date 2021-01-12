using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIPanelResearchUnit : MonoBehaviour
{
    public UIPanelUpgradeUnit panelUpgradeUnit;
    public MobData MobData;
    public int cost;
    public List<GameObject> PrefabsUnitForLevel;

    public int currentLevel;
    public bool isMaxLevel => PrefabsUnitForLevel.Count >= currentLevel-1;

    public void Awake()
    {
        //currentLevel = 0;

        foreach (var unit in PrefabsUnitForLevel)
            if (unit.GetComponent<MobDataReference>().data != MobData)
                throw new System.Exception($"Unit unknow type {MobData}");
    }
 

    public void OpenUpgradePanel()
    {
        panelUpgradeUnit.Open(this);
    }
}
