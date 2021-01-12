using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

[SelectionBase]
public class NPCHealth : MonoBehaviour
{

    public int m_Health = 100;
    public Slider m_Slider;
    public bool isBase;
    public bool isDied => m_Health <= 0;
    private Team teamData;
    public bool isPlayer => teamData.teamId == 0;
    void Start()
    {
        teamData = GetComponent<Team>();
        if(isBase)
          m_Slider.gameObject.SetActive(false);
    }

    void OnApplyDamage(Damage damage)
    {
        m_Health -= damage.amount;
        if (isBase)
        {
            m_Slider.gameObject.SetActive(true);
            m_Slider.value = m_Health;
        }
        if (isDied)
        {
             if(!isPlayer)
               PhotonNetwork.Instantiate("RagDoll_Units/Orcs/Orc_light_infantry", transform.position, transform.rotation);
             else
                   {
                PhotonNetwork.Instantiate("RagDoll_Units/Players/WK_light_infantry_A", transform.position, transform.rotation);
                 }

            damage.sender.SendMessage("OnTargetKill",
                SendMessageOptions.DontRequireReceiver);


            gameObject.SendMessage("OnDie", 
                SendMessageOptions.DontRequireReceiver);
        }
    }
}
