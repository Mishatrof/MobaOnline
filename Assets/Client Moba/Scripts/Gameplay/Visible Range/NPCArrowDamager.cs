using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCArrowDamager : MonoBehaviour
{
    public float m_DeltaHit = 1f;
    public Arrow m_Bullet;
    public Transform m_PointStartBullet;
    public bool isTower;
    public AudioSource AS;
    public AudioClip shoot;
    void OnNewTarget(Transform target)
    {
        StartCoroutine(AttackHandler(target));
    }
    void Start()
    {
       
        AS = GetComponent<AudioSource>();
       
    }

    void OnLostTarget()
    {
        StopAllCoroutines();
    }

    void CreateAndInitBullet(Transform target)
    {
        var newbullet = Instantiate(m_Bullet, m_PointStartBullet.position, Quaternion.identity);
        AS.PlayOneShot(shoot);
        newbullet.SetTarget(target);
        newbullet.m_Sender = gameObject;
    }

    IEnumerator AttackHandler(Transform target)
    {
        while (target != null)
        {

            CreateAndInitBullet(target);
            yield return new WaitForSeconds(m_DeltaHit);
        }
    }
}
