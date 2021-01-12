using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class UITimerSlider : MonoBehaviour
{

    public Slider m_Slider;
    public UnityEvent m_OnStartTimerEvent;
    public UnityEvent m_OnStopTimerEvent;

    float m_Timer;
    float m_InitTime;

    public void StartTimer(float time)
    {
        enabled = true;
        m_Timer = time;
        m_InitTime = time;
        m_OnStartTimerEvent.Invoke();
    }

    void Update()
    {
        m_Timer -= Time.deltaTime;

        if (m_Slider != null)
            m_Slider.value = m_Timer / m_InitTime;

        if (m_Timer <= 0f)
        {
            m_OnStopTimerEvent.Invoke();
            enabled = false;
        }
    }
}
