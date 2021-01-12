using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdateMobsListForCasernesListener
{
    void ChangedList(MobsForFillsCasernes list);
}

public class MobsForFillsCasernes : MonoBehaviour
{
    public List<GameObject> mobs;
}
