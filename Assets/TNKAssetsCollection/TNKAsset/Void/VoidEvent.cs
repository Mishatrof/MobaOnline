using System.Collections.Generic;
using UnityEngine;

namespace MyAsset
{
	[CreateAssetMenu(menuName="My Asset/Events/Void")]
    public class VoidEvent : ScriptableObject
    {
        private List<IVoidEventListener> m_Listeners = new List<IVoidEventListener>();


        public void AddListener(IVoidEventListener listener)
        {
            m_Listeners.Add(listener);
        }


        public void RemoveListener(IVoidEventListener listener)
        {
            m_Listeners.Remove(listener);
        }


        public void Raise()
        {
            for (int i = m_Listeners.Count - 1; i >= 0; i--)
                m_Listeners[i].OnEventRaised();
        }


        public int countListeners
        {
            get { return m_Listeners.Count; }
        }
    }
}