using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour
{
    public GameObject Hero;
    public Text HpText;
    public Slider HpSlider;

    public IntVariable m_Money;
    public GameObject[] Towers_P;
    public GameObject[] Towers_O;
    public bool isCam;
    // Update is called once per frame
    void Start()
    {
        if(Hero == null)
        Hero = GameObject.Find("P_SuperHero(Clone)");
        UpdateHp();
    }
    void Update()
    {

        if (Hero == null)
            Hero = GameObject.Find("P_SuperHero(Clone)");


        if (Input.GetKey(KeyCode.L))
        {
            m_Money.m_RuntimeValue += 10000;
        }
        if (Input.GetKey(KeyCode.K))
        {
            for (int i = 0; i < 12; i++)
            {
                Towers_P[i].SetActive(false);
            }
        }
        if (Input.GetKey(KeyCode.J))
        {
            for (int i = 0; i < 12; i++)
            {
                Towers_O[i].SetActive(false);
            }
        }
    }

    public void UpdateHp()
    {
        if (!isCam && Hero != null && Hero.TryGetComponent(out NPCHealth h))
        {
             HpText.text = h.m_Health.ToString();
             HpSlider.value = h.m_Health;
        }
    }
}
