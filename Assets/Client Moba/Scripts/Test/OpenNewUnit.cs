using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNewUnit : MonoBehaviour
{
    public GameObject mob;

    [ContextMenu("Open")]
    public void Open()
    {
        var list = FindObjectOfType<MobsForFillsCasernes>();
        list.mobs.Add(mob);

        EventBus.Raise<IUpdateMobsListForCasernesListener>(l => l.ChangedList(list));
    }
}
