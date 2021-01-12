using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    [SerializeField]
    private TeamData m_Data;


    public int teamId = -1;

    public TeamData data { set { m_Data = value; } get { return m_Data; } }
}
