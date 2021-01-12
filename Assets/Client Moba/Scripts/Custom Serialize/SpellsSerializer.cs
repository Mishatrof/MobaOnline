using UnityEngine;
using System;

namespace CustomSerialization.Spell
{
    [CreateAssetMenu(menuName="Custom Serialize/Spells")]
    public class SpellsSerializer : MasterSerialize<Components, Data>
    { }

    [Serializable]
    public class Components : EntityComponents, ISetEntityData<Data>
    {
        public RPGGame.Spell spell;

        public void SetData(Data data)
        {
            spell.cost = data.cost;
        }
    }

    [Serializable]
    public struct Data : ISetEntityData<Components>
    {
        public int cost;

        public void SetData(Components components)
        {
            cost = components.spell.cost;
        }
    }  
}

