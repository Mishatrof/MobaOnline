#pragma warning disable 0649
using UnityEngine.Events;
using UnityEngine;

namespace MyAsset
{

	public abstract class GameEventListener<T, E, UER> : MonoBehaviour, IListener<T> where E : GameEvent<T> where UER : UnityEvent<T>
	{
		[SerializeField]
		protected E m_ListenedEvent;
		[SerializeField]
        protected UER m_Response;


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


		public virtual void OnInvoke(T arg)
		{
			m_Response.Invoke(arg);
		}
	}

}