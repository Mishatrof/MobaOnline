using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateArmy : MonoBehaviour
{
     public int PlayerCommand; // команда игрока
    public GameObject UpdatePanel;
    
    public Transform CellMenu;

    public GameObject sprite1;
    public GameObject sprite2;

    public Sprite sp1;
    public Sprite sp2;
    public Sprite sp3;
    public Sprite sp4;
    public Sprite sp5;
    public Sprite sp6;

    public GameObject pan;
    public GameObject ArmyOrk1;
    public GameObject ArmyOrk2;
    public GameObject ArmyOrk3;
    public GameObject ArmyHuman1;
    public GameObject ArmyHuman2;
    public GameObject ArmyHuman3;
    public int ID;

    public bool is1;
    public bool is2;
    public bool is3;
    public bool is4;
    public bool is5;
    public bool is6;
    public void OpenUpdate(int _id)
    {

        UpdatePanel.SetActive(true);
        if (PlayerCommand == 1)
        {
            switch (_id)
            {
                case 0:
                    if(is1 == false)
                    {
                        Transform Go1 = Instantiate(ArmyHuman1, transform.position, transform.rotation).transform;
                        Go1.SetParent(CellMenu);
                        is1 = true;
                    }
                    sprite1.GetComponent<Image>().sprite = sp1;
                    sprite2.GetComponent<Image>().sprite = sp2;
                    ID = _id;
                    break;
                case 1:
                    if (is2 == false)
                    {
                        Transform Go2 = Instantiate(ArmyHuman2, transform.position, transform.rotation).transform;
                        Go2.SetParent(CellMenu);
                        is2 = true;
                    }
                    sprite1.GetComponent<Image>().sprite = sp3;
                    sprite2.GetComponent<Image>().sprite = sp4;
                    ID = _id;
                    break;
                case 2:
                    if (is3 == false)
                    {
                        Transform Go3 = Instantiate(ArmyHuman3, transform.position, transform.rotation).transform;
                        Go3.SetParent(CellMenu);
                        is3 = true;
                    }
                    sprite1.GetComponent<Image>().sprite = sp5;
                    sprite2.GetComponent<Image>().sprite = sp6;
                    ID = _id;
                    break;
            }
            
        }
        if (PlayerCommand == 2)
        {
            switch (_id)
            {
                case 0:
                    sprite1.GetComponent<Image>().sprite = sp1;
                    sprite2.GetComponent<Image>().sprite = sp2;
                    ID = _id;
                    break;
                case 1:
                    sprite1.GetComponent<Image>().sprite = sp3;
                    sprite2.GetComponent<Image>().sprite = sp4;
                    ID = _id;
                    break;
                case 2:
                    sprite1.GetComponent<Image>().sprite = sp5;
                    sprite2.GetComponent<Image>().sprite = sp6;
                    ID = _id;
                    break;
            }

        }

    }

    public void UpdateCurrent()
    {
        if (PlayerCommand == 1)
        {
            switch (ID)
            {
                case 0:
                    Transform Go1 = Instantiate(ArmyHuman1, transform.position, transform.rotation).transform;
                    Go1.SetParent(CellMenu);
                    break;
                case 1:
                    Transform Go2 = Instantiate(ArmyHuman2, transform.position, transform.rotation).transform;
                    Go2.SetParent(CellMenu);
                    break;
                case 2:
                    Transform Go3 = Instantiate(ArmyHuman3, transform.position, transform.rotation).transform;
                    Go3.SetParent(CellMenu);
                    break;
            }
        }
    }
 
}
