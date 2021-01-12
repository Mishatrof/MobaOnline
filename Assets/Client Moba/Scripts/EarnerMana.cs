using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnerMana : MonoBehaviour
{
    public IntVariable m_Mana;
    public int m_ManaUpValue;


    // Update is called once per frame
    void OnEnable()
    {
        StartCoroutine(HandleManaUp());
    }


    private IEnumerator HandleManaUp()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);

            m_Mana.m_RuntimeValue += m_ManaUpValue;

            m_Mana.m_RuntimeValue = Mathf.Clamp(m_Mana.m_RuntimeValue, 0, m_Mana.m_InitialValue);
        }
    }
}
