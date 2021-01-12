using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public class EcsNPCDamager : MonoBehaviour
    {
        public int m_Damage;
        public float m_DeltaHit = 0.5f;


        void OnNewTarget(Transform target)
        {
            StartCoroutine(AttackHandler(target.GetComponent<GameObjectEntity>()));
        }


        void OnLostTarget()
        {
            StopAllCoroutines();
        }


        IEnumerator AttackHandler(GameObjectEntity target)
        {
            while (target != null)
            {
                TakeDamage(target);

                yield return new WaitForSeconds(m_DeltaHit);
            }
        }

        void TakeDamage(GameObjectEntity target)
        {
            var damage = target.EnsureComponent<DamageComponent>();
            damage.amout += m_Damage;
        }
    }
}
