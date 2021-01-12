using UnityEngine.Events;
using UnityEngine;

namespace MyAsset
{
    [AddComponentMenu("My Asset/Event/Listeners/Void")]
    public class VoidListener : MonoBehaviour, IVoidEventListener
    {
        [SerializeField]
        private VoidEvent m_ListenedEvent;
        [SerializeField]
        private UnityEvent m_Responce;


        public void OnEventRaised()
        {
            m_Responce.Invoke();
        }


        private void OnEnable()
        {
            if (m_ListenedEvent)
                m_ListenedEvent.AddListener(this);
        }


        private void OnDisable()
        {
            if (m_ListenedEvent)
                m_ListenedEvent.RemoveListener(this);
        }
    }
}