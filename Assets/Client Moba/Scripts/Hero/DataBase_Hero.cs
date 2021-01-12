using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataBase_Hero : MonoBehaviour
{
    public  List<GameObject>  Heroes = new List<GameObject>(); 
    public  List<LevelHero> Level;
}

[System.Serializable]
public struct LevelHero
{
    public int m_Add_Health;
    public int m_Add_Damage;
    public int Lvl;
    public string Name;

}

