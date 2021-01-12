using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using  TMPro;


public class Hero_DataItem : MonoBehaviour
{

   private DataBase_Hero DB_HERO;
   
   public int m_Damage;
   public int m_Health;
   private string nameField;
   private string LvlField;


   public TextMeshProUGUI DamagHeroText;
   public TextMeshProUGUI HealthHeroText;
   public Text[] NameHeroText;
   public Text[] LvlHeroText;


   [Space(5)] 
   public TMP_InputField InputField1;
   public TMP_InputField InputField2;
   void Awake()
   {
      DB_HERO = GetComponent<DataBase_Hero>();
   }

   public void TakeInfo(int ID_HERO)
   {
    

     
      m_Damage = DB_HERO.Level[ID_HERO].m_Add_Damage;
      m_Health = DB_HERO.Level[ID_HERO].m_Add_Health;
      nameField = DB_HERO.Level[ID_HERO].Name;
      LvlField = DB_HERO.Level[ID_HERO].Lvl + "";
      SetInfo(ID_HERO);

   }

   void SetInfo(int ID_HERO)
   {
      if (DB_HERO.Heroes.Count > 1)
      {
         for (int i = 0; i < DB_HERO.Heroes.Count; i++)
         {
            DB_HERO.Heroes[i].SetActive(false);
         }
      }
      DB_HERO.Heroes[ID_HERO].SetActive(true);
      for (int i = 0; i < NameHeroText.Length; i++)
      {
         NameHeroText[i].text =  nameField;
      }
      for (int i = 0; i < LvlHeroText.Length; i++)
      {
         LvlHeroText[i].text =  LvlField;
      }
     
      DamagHeroText.text =  m_Damage + "";
      HealthHeroText.text =  m_Health + "";
   }


   public void Debug_SetInfo()
   {
      DamagHeroText.text = InputField1.text;
      HealthHeroText.text = InputField2.text;
  
   }
}
