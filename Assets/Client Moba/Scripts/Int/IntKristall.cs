using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntKristall : MonoBehaviour
{

    public float m_Value;
    public Slider SliderValue;
    
    void Start()
    {
        m_Value = 0;
    }

   
    void Update()
    {
        if (m_Value <= 10)
        {
            m_Value += Time.deltaTime / 2;
        }

        SliderValue.value = m_Value;
    }
}
