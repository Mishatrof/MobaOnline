using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAsset
{
    public abstract class ScriptableObjectList<T, E> : ScriptableObject, IEnumerable<T>
        where E : GameEvent<T>
    {
        [SerializeField]
        private List<T> m_List = new List<T>();

        [SerializeField]
        private E m_Added;
        [SerializeField]
        private E m_Removed;

        public int Count { get { return list.Count; } }

        public virtual void Add(T item)
        {
            if (m_List.Contains(item))
                return;

            m_List.Add(item);
            m_Added?.Raise(item);
        }

        public virtual void Remove(T item)
        {
            if (!m_List.Contains(item))
                return;

            m_List.Remove(item);
            m_Removed?.Raise(item);
        }

        public T Find(System.Predicate<T> match)
        {
            return m_List.Find(match);
        }

        public void Clear()
        {
            m_List.Clear();
        }

        public bool Contains(T item)
        {
            return m_List.Contains(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return m_List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_List.GetEnumerator();
        }

        public T this[int index]
        {
            get { return m_List[index]; }
            set { m_List[index] = value; }
        }

        public List<T> list
        {
            get { return m_List; }
            set { m_List = value; }
        }
    }
}
