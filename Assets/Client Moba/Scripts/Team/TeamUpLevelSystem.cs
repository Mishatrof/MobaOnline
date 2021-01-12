using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamUpLevelSystem : MonoBehaviour
{
    public TeamsComponent teamsComponent;


    Coroutine c_process;

    void OnEnable() { c_process = StartCoroutine(Process()); }
    void OnDisable() { StopCoroutine(c_process); }

    IEnumerator Process()
    {
        var waiter = new WaitForSecondsRealtime(0.5f);

        while (true) {
            yield return waiter;

            foreach (var data in teamsComponent.m_TeamsConfig)
            {
                if (data.experience >= 1000)
                {
                    data.level += 1;
                    data.experience -= 1000;
                    data.isSync = false;
                }
            }
        }
    }
}
