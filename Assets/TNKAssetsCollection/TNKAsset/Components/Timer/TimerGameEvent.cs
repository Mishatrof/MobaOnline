using UnityEngine;

namespace MyAsset.Timer
{
    [AddComponentMenu("My Asset/Timers/Timer IEnumerator Game Event")]
    public class TimerGameEvent : TimerIEnumerator
	{
        [SerializeField]
        private FloatEvent m_TimerEvent;


        protected override void TickTimer(float timer)
        {
            m_TimerEvent.Raise(timer);
        }
    }

}
