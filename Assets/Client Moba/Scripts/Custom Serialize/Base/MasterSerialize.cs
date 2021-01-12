using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using CustomSerialization.Base;

using Random = UnityEngine.Random;


namespace CustomSerialization
{
    public abstract class MasterSerialize<C, D> : ScriptableObject
        where C : EntityComponents, ISetEntityData<D>
        where D : struct, ISetEntityData<C>
    {
        [SerializeField]
        private string m_PathFile = "data.xml";
        [SerializeField]
        private Format m_Format = Format.bin;
        [SerializeField]
        protected List<C> m_SerializableObjects;
        
        public string path => Path.ChangeExtension(m_PathFile, m_Format.ToString());


        public void Serialize()
        {
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                new DicrionarySerializer<D>(m_Format).Serialize(stream, CopyDataFromListToDictionary());
            }
        }
        
        public void Deserialize()
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                CopyDataFromDictionaryToList(new DicrionarySerializer<D>(m_Format).Deserialize(stream));
            }
        }


        protected void OnValidate()
        {
            foreach (C item in m_SerializableObjects)
            {
                if (item.uniqueID.Equals(string.Empty))
                    item.uniqueID = "ID_" + Random.Range(0, 9999);

                item.uniqueID = item.uniqueID.Replace(' ', '_');
            }
   

            for (int i = m_SerializableObjects.Count-1; i >= 0; i--)
            {
                C itemA = m_SerializableObjects[i];

                foreach (C itemB in m_SerializableObjects)
                {
                    if (itemA == itemB)
                        continue;

                    if (itemA.uniqueID.Equals(itemB.uniqueID))
                    {
                        Debug.Log("uniqueID already exists: " + itemA.uniqueID);
                        itemA.uniqueID = "ID_" + Random.Range(0, 9999);
                    }
                }
            }
        }


        private Dictionary<string, D> CopyDataFromListToDictionary()
        {
            Dictionary<string, D> dict = new Dictionary<string, D>();

            foreach (C item in m_SerializableObjects)
            {
                D data = new D();
                data.SetData(item);

                dict.Add(item.uniqueID, data);
            }

            return dict;
        }

        private void CopyDataFromDictionaryToList(Dictionary<string, D> dict)
        {
            foreach (C item in m_SerializableObjects)
            {
                if (dict.TryGetValue(item.uniqueID, out D data))
                    item.SetData(data);
            }
        }
    }

    [Serializable]
    public abstract class EntityComponents
    {
        public string uniqueID = "ID_0";
    }


    public interface ISetEntityData<T>
    {
        void SetData(T data);
    }
}
