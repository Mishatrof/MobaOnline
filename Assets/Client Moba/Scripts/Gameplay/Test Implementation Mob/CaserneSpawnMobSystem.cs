using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaserneSpawnMobSystem : MonoBehaviour
{
    public CaserneListComponent m_CaserneList;

    void Spawn()
    {
        foreach(var caserne in m_CaserneList.list)
        {
            foreach (var mob in caserne.spawnMobs)
            {
                Vector3 spawnpos = caserne.spawnPoint.position + new Vector3(Random.value, 0f, Random.value) * Random.Range(-1.5f, 1.5f);

                var newmob = PhotonNetwork.Instantiate(mob.name, spawnpos, Quaternion.identity);
                var newmobComponent = newmob.GetComponent<MobComponent>();

                newmobComponent.team = caserne.team;
            }
        }
    }
}
