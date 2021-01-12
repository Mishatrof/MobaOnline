using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Crip : MonoBehaviour
{

  
    #region Varibales

    #region Settings
    [Header("ЭТО БОТ")]
    public bool isBOT;
    public bool isMyTeam;
    private bool IsTARGETTING;
    [Header("ЛУЧНИК")]
    public bool IsArrowHead;
    [Header("БАШНЯ")]
    public bool isTower;
    [Header("СТРЕЛЛА ДЛЯ БАШНИ")]
    public GameObject arrow;
    private NavMeshAgent agent;
    private GameObject AnimModel;
    private Animator Anim;
    private bool baza;
    [Header("ЦЕЛЬ")]
    public Transform Target;
    [Header("ЦЕЛЬ С КРИПОМ")]
    public Transform enemy;
    
    float range = 5f;
    
    [Header("ДАМАГ")]
    public float Hit;
    private List<GameObject> allobj = new List<GameObject>();
    [Header("Cooldown")]
    public float currCoolDown, Cooldown;
    int j = 0;
    [Space]
    #endregion

    private List<GameObject> obj = new List<GameObject>();
    private List<GameObject> tower = new List<GameObject>();

    private int currentEnemy;
    private int currentTower;

    #region Distance
    [Header("ДИСТАНЦИЯ АТТАКИ")]
    public float attackDist;
    [Header("ДИСТАНЦИЯ КРИПА")]
    public float agentDist;
    public float MaxDist;
    #endregion

    #region Prior
    public enum Priority
    {
        Baza,
        Enemy,
        Tower
    }

    [Space]

    [Header("Priority")]
    public Priority prior;
    #endregion

    #endregion

    // Start is called before the first frame update
    void Start()
    {
       
      // Anim = GetComponentInChildren<Animator>();
        if (!isTower)
        {
            agent = GetComponent<NavMeshAgent>();
            agent.SetDestination(Target.transform.position);
        }
        if (isTower)
        {
            prior = Priority.Enemy;
        }
        if (isBOT)
            isMyTeam = false;
        else
            isMyTeam = true;
    }

    
    
    void Shoot()
    {
        if (enemy == null)
            return;
        if (!CanShoot())
            return;
      
        currCoolDown = Cooldown;
        if (!isTower)
        {
            if (IsArrowHead)
            {
                GameObject bull = Instantiate(arrow);

                bull.transform.position = transform.position + new Vector3(0, 0, 0);
                bull.GetComponent<Arrow>().SetTarget(enemy);
                enemy.GetComponent<Health>().TakeDamage(Hit);
               
            }
            else
            {
              
                agent.SetDestination(enemy.transform.position);
                //    Anim.SetBool("Run", false);
                //   Anim.SetBool("Attack", true);
               // pView.RPC("TakeDamage", RpcTarget.All, Hit);
               enemy.GetComponent<Health>().TakeDamage(Hit);
            }
        }
        else if(isTower)
        {
           
            GameObject bull = Instantiate(arrow);
           
            bull.transform.position = transform.position  + new Vector3(0,3,0);
            bull.GetComponent<Arrow>().SetTarget(enemy);
            enemy.GetComponent<Health>().TakeDamage(Hit);

        }
       
                   
    }


    bool CanShoot()
    {
        if (currCoolDown <= 0)
            return true;
        return false;
    }

    
    public bool CripExits()
    {
        int f = 0;
        for(int i = 0; i < obj.Count; i++)
        {
            if(obj[i] == null)
            {
                f += 1;
            }
        }
        if (f == obj.Count)
            return true;
        return false;
    }


    void Update()
    {
        if (enemy == null)
        {
            if (!isTower)
                prior = Priority.Baza;
            baza = true;
        }
        if (baza)
        {
            if (!isTower)
            {
              //  Anim.SetBool("Run", true);
              //  Anim.SetBool("Attack", false);
                if (agent.destination != Target.transform.position) 
                    agent.SetDestination(Target.transform.position);
                else
                    return;
            }
        }
        else
          if (enemy != null)
            if (!isTower)
            {
                if (agent.destination != enemy.transform.position)
                    agent.SetDestination(enemy.transform.position);
                else
                {
                    prior = Priority.Baza;
                    return;
                }

            }
        if (enemy != null)
        {
            float dist = Vector3.Distance(transform.position, enemy.position);
            if (prior == Priority.Enemy)
            {
                if (dist <= attackDist)
                {
                    Shoot();
                    baza = false;
                }
                else if (dist > attackDist && dist <= agentDist)
                    baza = false;
                else if (dist > agentDist && dist >= MaxDist)
                    enemy = null;
            }
            else if (prior == Priority.Baza)
            {
                if (dist <= attackDist)
                {

                    Shoot();
                    baza = false;
                }
                else
                    baza = true;
            }
            else if (prior == Priority.Tower)
            {
                if (dist <= attackDist)
                {
                    Shoot();
                    baza = false;
                }
                else
                    baza = true;

            }
        }
        else
        {

            if (CripExits())
            {
                if (currentTower < 0)
                    currentTower = 1;
                if (tower.Count > 0)
                    if (currentTower <= tower.Count - 1)
                    {
                        if (tower[currentTower] == null)
                        {
                            currentTower += 1;
                        }
                        else
                        {
                            enemy = tower[currentTower].transform;
                        }
                    }
                    else
                    {
                        currentTower -= 1;
                    }
            }
            else
            {
                if (currentEnemy < 0)
                    currentEnemy = 1;
                if (obj.Count > 0)
                    if (currentEnemy <= obj.Count - 1)
                    {
                        if (obj[currentEnemy] == null)
                        {
                            currentEnemy += 1;
                        }
                        else
                        {
                            enemy = obj[currentEnemy].transform;
                        }
                    }
                    else
                    {
                        currentEnemy -= 1;
                    }
            }
            baza = true;
        }

            if (currCoolDown > 0)
                currCoolDown -= Time.deltaTime;

    }
   
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Crip")
        {
            if (other.gameObject.GetComponent<Crip>().isMyTeam != gameObject.GetComponent<Crip>().isMyTeam)
            {
                obj.Add(other.gameObject);
                prior = Priority.Enemy;
            }
        }
        else if (other.gameObject.tag == "Tower")
        {
            if (other.gameObject.GetComponent<Crip>().isMyTeam != gameObject.GetComponent<Crip>().isMyTeam)
            {
                tower.Add(other.gameObject);
                prior = Priority.Tower;
            }
        }
        else return;
    }
}
