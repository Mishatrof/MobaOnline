using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntVariable : ScriptableObject
{
    public int m_InitialValue;
    public int m_RuntimeValue;
   

    void OnEnable()
    {    
        
        m_RuntimeValue = m_InitialValue;
    }
}
