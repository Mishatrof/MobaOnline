using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Text))]
public class VisualTextTimer : Timer
{
    private Text m_Text;

    protected void Start()
    {
        m_Text = GetComponent<Text>();
    }


    protected override void OnTickTimer(float remainedTime, float startTime)
    {
        m_Text.text = "Время, до следующей волны:  " +  remainedTime.ToString("0.0");
    }

    protected override void OnStopTimer()
    {
        m_Text.text = "0.0";
    }
}
