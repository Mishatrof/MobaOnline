using UnityEngine;
using System;

namespace CustomSerialization.Mob
{
    [CreateAssetMenu(menuName="Custom Serialize/Mobs")]
    public class MobsSerializer : MasterSerialize<Components, Data>
    { }

    [Serializable]
    public class Components : EntityComponents, ISetEntityData<Data>
    {
        public MobDamager damager;
        public HealthComponent healthComponent;

        public void SetData(Data data)
        {
            damager.hitSpeed = data.hit_speed;
            damager.damage = data.damage;
            healthComponent.health = data.health;
        }
    }

    [Serializable]
    public struct Data : ISetEntityData<Components>
    {
        public float hit_speed;
        public int damage;
        public int health;

        public void SetData(Components components)
        {
            hit_speed = components.damager.hitSpeed;
            damage = components.damager.damage;
            health = components.healthComponent.health;
        }
    }
}

