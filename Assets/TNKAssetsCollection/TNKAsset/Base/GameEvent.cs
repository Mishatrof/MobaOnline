using UnityEngine;
using System.Collections.Generic;

namespace MyAsset
{

	public abstract class GameEvent<T> : ScriptableObject
	{
		private List<IListener<T>> m_Listeners = new List<IListener<T>>();


		public void AddListener(IListener<T> listener)
		{
			m_Listeners.Add(listener);
		}


		public void RemoveListener(IListener<T> listener)
		{
			m_Listeners.Remove(listener);
		}


		public void Raise(T arg)
		{
			for (int i = m_Listeners.Count - 1; i >= 0; i--)
				m_Listeners[i].OnInvoke(arg);
		}


        public int countListeners
        {
            get { return m_Listeners.Count; }
        }
	}

}