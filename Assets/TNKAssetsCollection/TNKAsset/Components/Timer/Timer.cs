using System.Collections;
using UnityEngine.Events;
using UnityEngine;
//using MyAsset;

namespace MyAsset.Components
{
    [AddComponentMenu("My Asset/Components/Timers")]
	public class Timer : MonoBehaviour
	{
        [SerializeField]
        private float m_Timer = 10f;
        [SerializeField]
        private bool m_StartOnAwake = false;
        [SerializeField]
        private bool m_CycleTimer = false;
        [SerializeField]
        private FloatEvent m_EventTickTimer = null;
        [SerializeField]
        private UnityEvent m_OnFinishedTimer = null;

        private Coroutine m_HandleTimer;
        private const float k_DeltaTime = 0.099f;
        private const float k_DeltaTimeTickEvent = 0.299f;


        #region property
        public float timer
        {
            get { return m_Timer; }
            set
            {
                if (m_HandleTimer == null)
                    m_Timer = value;
                else
                    m_Timer = Mathf.Clamp(value, 0f, float.MaxValue);
            }
        }


        public bool cycleTimer
        {
            get { return m_CycleTimer; }
            set { m_CycleTimer = value; }
        }
        #endregion


        private void Awake()
        {
            if (m_StartOnAwake)
                StartTimer(m_Timer);
        }


        private IEnumerator HandleTimer()
        {
            WaitForSeconds waiter = new WaitForSeconds(k_DeltaTime);
            float startTimer = m_Timer;

            do
            {
                while (m_Timer > 0f)
                {
                    yield return waiter;
                    m_Timer -= k_DeltaTime;
                }

                m_Timer = startTimer;
                m_OnFinishedTimer.Invoke();

            } while (m_CycleTimer && m_Timer != 0f);

            m_HandleTimer = null;
            m_Timer = 0f;
        }


		public void StartTimer(float time)
		{
            if (m_HandleTimer == null)
            {
                m_Timer = time;
                m_HandleTimer = StartCoroutine(HandleTimer());
                StartProccesingCallEventTickTimer();
            }
		}


        [ContextMenu("StartTimer")]
        public void StartTimer()
        {
            StartTimer(m_Timer);
        }


        [ContextMenu("StopTimer")]
        public void StopTimer()
		{
            if (m_HandleTimer != null)
            {
                StopCoroutine(m_HandleTimer);
                StopProccesingCallEventTickTimer();
            }
		}


        #region Call Event TickTimer

        private IEnumerator HandleCallEventTickTimer()
        {
            WaitForSeconds waiter = new WaitForSeconds(k_DeltaTimeTickEvent);

            while (true)
            {
                m_EventTickTimer.Raise(m_Timer);
                yield return waiter;
            }
        }


        private void StartProccesingCallEventTickTimer()
        {
            if (m_EventTickTimer)
                StartCoroutine(HandleCallEventTickTimer());
        }


        private void StopProccesingCallEventTickTimer()
        {
            StopCoroutine("HandleCallEventTickTimer");
        }

        #endregion
    }

}
