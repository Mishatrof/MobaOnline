using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPCDamager : MonoBehaviour
{
    public int m_Damage = 5;
    public float m_DeltaHit = 1f;
    public GameObject bullet;
    public bool isTower;
    public Animator Anim;
    public GameObject DmgTextPrefab;
    public Text DmgText;

    public MobDataReference data;

    void Start()
    {
        data = GetComponent<MobDataReference>();
        m_Damage = data.data.Level[0].m_Damage;
        m_DeltaHit = data.data.SpeedAttack;
    }
    void OnNewTarget(Transform target)
    {
        if (isTower)
        {
          
            GameObject Go = Instantiate(bullet, transform.position, Quaternion.identity);
         
            Go.GetComponent<Arrow>().SetTarget(target);
          
        }

        //  if (Anim != null) Anim.CrossFadeInFixedTime("Attack", 0.1f);
        StartCoroutine(AttackHandler(target));
    }


    void OnLostTarget()
    {
        StopAllCoroutines();
    }


    IEnumerator AttackHandler(Transform target)
    {
        while (target != null)
        {
            target.SendMessage("OnApplyDamage", new Damage { sender = gameObject, amount = m_Damage },
                SendMessageOptions.DontRequireReceiver);
            
            Anim.Play("Attack");
          GameObject Go =   Instantiate(DmgTextPrefab, transform.position, Quaternion.identity);
          DmgText = Go.transform.GetChild(0).GetComponent<Text>();
          DmgText.text = "" + m_Damage;
      
            yield return new WaitForSeconds(m_DeltaHit);
        }
    }

}
