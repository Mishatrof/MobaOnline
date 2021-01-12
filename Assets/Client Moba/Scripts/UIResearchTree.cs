using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIResearchTree : MonoBehaviour
{
    public IntVariable m_Money;

    public void ResearchMob(GameObject mob)
    {
        var list = FindObjectOfType<MobsForFillsCasernes>();
        list.mobs.Add(mob);

        EventBus.Raise<IUpdateMobsListForCasernesListener>(l => l.ChangedList(list));
    }
}
