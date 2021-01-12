using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public abstract class Timer : MonoBehaviour
{
    private bool m_IsWorkTimer;


    public void StartTimer(float time)
    {
        if (m_IsWorkTimer)
        {
            StopAllCoroutines();
        }

        StartCoroutine(TimerHandle(time));
        m_IsWorkTimer = true;
    }


    public IEnumerator TimerHandle(float time)
    {
        float timer = time;

        while(timer > 0f)
        {
            yield return new WaitForFixedUpdate();
            timer -= Time.fixedDeltaTime;
            OnTickTimer(timer, time);
        }

        m_IsWorkTimer = false;

        OnStopTimer();
    }


    protected abstract void OnTickTimer(float remainedTime, float startTime);
    protected abstract void OnStopTimer();
}
