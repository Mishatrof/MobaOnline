using UnityEngine;

namespace MyAsset.Timer
{
    [AddComponentMenu("My Asset/Timers/Timer IEnumerator Unity Event")]
	public class TimerUnityEvent : TimerIEnumerator
	{
        [SerializeField]
        private FloatUnityEvent m_TimerEvent;


        protected override void TickTimer(float timer)
        {
            m_TimerEvent.Invoke(timer);
        }
    }

}
