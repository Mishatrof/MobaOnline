using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SystemLager : MonoBehaviour
{
    public GameObject[] prefabsSpawned;
    public GameObject[] prefabsAlive;
    public Transform m_TargetPoint;
    public bool isBoss;
    public bool isAirLager;
    public bool isLager;
    Team teamComponent;
    public TeamData team => GetComponent<Team>().data;
    public bool isDead = false;
    // Start is called before the first frame update
   public void Start()
    {
        teamComponent = GetComponent<Team>();
    }
    public void Update()
    {
        CheckLive();
    }

   
    public void CheckLive()
    {
        if (isBoss)
        {
            if (prefabsAlive[0].gameObject == null)
            {

              
                RespawnBoss();

            }
        }
        if (isAirLager)
        {
            if (prefabsAlive[0].gameObject == null && prefabsAlive[1].gameObject == null)
            {

               
                RespawnAir();

            }
        }
        if (isLager)
        {
            if (prefabsAlive[0].gameObject == null &&
                prefabsAlive[1].gameObject == null &&
                prefabsAlive[2].gameObject == null &&
                prefabsAlive[3].gameObject == null &&
                prefabsAlive[4].gameObject == null)
            {


                RespawnLarge();

            }
        }
    }
    public void RespawnBoss()
    {
        

                for (int i = 0; i < prefabsSpawned.Length; i++)
                {
                    object[] data = new object[] { (byte)teamComponent.teamId };
                    GameObject newMob = PhotonNetwork.Instantiate(prefabsSpawned[i].name, transform.position, Quaternion.identity, 0, data);


                    if (newMob.GetComponent<Mob>())
                        newMob.GetComponent<Mob>().SetDestination(m_TargetPoint.position);

                    var controller = newMob.GetComponent<Client.Game.NPCMobNetwork>();
                    if (controller) controller.targetPoint = m_TargetPoint;

                
                }
               
            
        
        Destroy(gameObject);
    }
    public void RespawnAir()
    {

      

            for (int i = 0; i < prefabsSpawned.Length; i++)
            {
                object[] data = new object[] { (byte)teamComponent.teamId };
                GameObject newMob = PhotonNetwork.Instantiate(prefabsSpawned[i].name, transform.position, Quaternion.identity, 0, data);


                if (newMob.GetComponent<Mob>())
                    newMob.GetComponent<Mob>().SetDestination(m_TargetPoint.position);

                var controller = newMob.GetComponent<Client.Game.NPCMobNetwork>();
                if (controller) controller.targetPoint = m_TargetPoint;

            
            }

        

        Destroy(gameObject);
    }
    public void RespawnLarge()
    {



        for (int i = 0; i < prefabsSpawned.Length; i++)
        {
            object[] data = new object[] { (byte)teamComponent.teamId };
            GameObject newMob = PhotonNetwork.Instantiate(prefabsSpawned[i].name, transform.position, Quaternion.identity, 0, data);


            if (newMob.GetComponent<Mob>())
                newMob.GetComponent<Mob>().SetDestination(m_TargetPoint.position);

            var controller = newMob.GetComponent<Client.Game.NPCMobNetwork>();
            if (controller) controller.targetPoint = m_TargetPoint;


        }



        Destroy(gameObject);
    }


}
