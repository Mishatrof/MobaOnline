using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MobData : ScriptableObject
{
    public int Cout;
    public Sprite m_Sprite;
    public Sprite m_SpriteLost;
    public List<MobLevel> Level;
    public int Cost;
    public float Radius;
    public float SpeedAttack;
}

[System.Serializable]
public struct MobLevel
{
    public int m_Health;
    public int m_Damage;
    public Sprite m_Sprite;
}

public enum TypeUnit
{
    Archer, Swordman, Default
}
