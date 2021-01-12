using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIPanelUpgradeUnit : MonoBehaviour
{
    public Image m_Image1;
    public Image m_Image2;
    public IntVariable m_Money;

    UIPanelResearchUnit panelResearchUnit;
    public int cost_m;
    public void Open(UIPanelResearchUnit researchUnit)
    {
        panelResearchUnit = researchUnit;

        m_Image1.sprite = researchUnit.PrefabsUnitForLevel[0].GetComponent<MobDataReference>().data.m_Sprite;
        m_Image2.sprite = researchUnit.PrefabsUnitForLevel[0].GetComponent<MobDataReference>().data.m_SpriteLost;
        cost_m = researchUnit.PrefabsUnitForLevel[0].GetComponent<MobDataReference>().data.Cost;
        Debug.Log(m_Image1.sprite);
        Debug.Log(m_Image2.sprite);
        gameObject.SetActive(true);
    }

    public void ResearhUnit()
    {
        var mobList = FindObjectOfType<MobsForFillsCasernes>();

        if (mobList.mobs.Contains(panelResearchUnit.PrefabsUnitForLevel[0]))
            return;
        if (m_Money.m_RuntimeValue < cost_m)
            return;

        m_Money.m_RuntimeValue -= cost_m;
        mobList.mobs.Add(panelResearchUnit.PrefabsUnitForLevel[0]);
        EventBus.Raise<IUpdateMobsListForCasernesListener>(l => l.ChangedList(mobList));
    }

    public void UpgradeUnit()
    {
        if (panelResearchUnit.currentLevel + 1 >= panelResearchUnit.PrefabsUnitForLevel.Count)
            return;

        panelResearchUnit.currentLevel += 1;

        var newmob = panelResearchUnit.PrefabsUnitForLevel[panelResearchUnit.currentLevel];
        


        var mobList = FindObjectOfType<MobsForFillsCasernes>();
        
        for(int i = 0; i < mobList.mobs.Count; i++)
        {
            if (mobList.mobs[i].GetComponent<MobDataReference>().data == panelResearchUnit.MobData)
                mobList.mobs[i] = newmob;
        }
    }
}
