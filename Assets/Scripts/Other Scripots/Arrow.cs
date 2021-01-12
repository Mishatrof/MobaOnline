using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject m_Sender;
    public Transform Target;
    public int damage = 40;
    public float speed = 25f;

    // Update is called once per frame
    void LateUpdate()
    {
        Move();
    }

    public void SetTarget(Transform _Target)
    {
        Target = _Target;


    }
    public void Move()
    {
        if (Target != null)
        {
            var newpos = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * speed);
            transform.position = newpos;
           

            if (Vector3.Distance(transform.position, Target.position) < 0.3f )
            {
                Destroy(gameObject);
                Target.SendMessage("OnApplyDamage", new Damage { amount = damage, sender = m_Sender },
                SendMessageOptions.DontRequireReceiver);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
