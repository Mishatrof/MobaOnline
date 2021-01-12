using RPGGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRightMenu : MonoBehaviour
{
    public MineTeamComponent MineTeam;
    public GameObject humanArmy; 
    public GameObject OrksArmy;


    public void OpenArmy()
    {
        switch (MineTeam.teamId)
        {
            case 0:
                humanArmy.SetActive(true); // если 1 , то откроется панель улучшения людей
                break;
            case 1:
                OrksArmy.SetActive(true);// если 2 , то откроется панель улучшения окров
                break;
        }
    }
}
