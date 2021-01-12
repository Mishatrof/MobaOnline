using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnerCrips : MonoBehaviour
{
    public float fireRate = 15f;
    public bool isBOT;
    
    [HideInInspector]public float firetimer;
    public Transform EnemySpawn;
    public Transform MySpawn;
    public Transform[] pos;
    public List<GameObject> crips = new List<GameObject>();
    private List<GameObject> sceneCrips = new List<GameObject>();
    public int maxCrips;

    public int CripsInSpawn;

    private void Start()
    {
       
        sceneCrips.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if (firetimer < fireRate)
            firetimer += Time.deltaTime;
        if (firetimer >= fireRate)
            for (int i = 0; i < CripsInSpawn; i++)
            {
                Spawn();

            }
    }
    
    void Spawn()
    {
        if (sceneCrips.Count < maxCrips)
        {
            if (!isBOT)
            {
                GameObject GO =Instantiate(crips[Random.Range(0, crips.Count)], pos[Random.Range(0, pos.Length)].transform.position, pos[Random.Range(0, pos.Length)].transform.rotation);
                GO.GetComponent<Crip>().isMyTeam = true;
                    GO.GetComponent<Crip>().Target = EnemySpawn;
                    sceneCrips.Add(GO);
            }
            else
            {
                GameObject GO = Instantiate(crips[Random.Range(0, crips.Count)], pos[Random.Range(0, pos.Length)].transform.position, pos[Random.Range(0, pos.Length)].transform.rotation);
                GO.GetComponent<Crip>().isBOT = true;
                    GO.GetComponent<Crip>().Target = MySpawn;
                    
                    sceneCrips.Add(GO);
            }
        }
        else return;

        firetimer = 0f;

        //SPAWN

    }
}
