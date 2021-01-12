using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class IntSlider : MonoBehaviour
{
    public IntVariable m_Variable;
    public Image m_ImageBar;


    
    void FixedUpdate()
    {
        m_ImageBar.fillAmount = (float)m_Variable.m_RuntimeValue / m_Variable.m_InitialValue;
    }
}
