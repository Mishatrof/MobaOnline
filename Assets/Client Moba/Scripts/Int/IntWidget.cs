using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Text))]
public class IntWidget : MonoBehaviour
{
    public IntVariable m_Variable;
    public bool isMoney;
    private Text m_Text;


    private void Start()
    {
        m_Text = GetComponent<Text>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(isMoney)
        m_Text.text = "Золото: " +  m_Variable.m_RuntimeValue.ToString();
        else
            m_Text.text = "Мана: " + m_Variable.m_RuntimeValue.ToString();
    }
}
