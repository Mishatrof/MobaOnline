using UnityEngine;
using System.Collections;

namespace MyAsset.Timer
{

	public abstract class TimerIEnumerator : MonoBehaviour
	{
        [SerializeField]
        private float m_DeltaTime = 0.1f;


		public IEnumerator Timer(float time)
		{
            float timer = time;


            while(timer > 0f)
            {
                TickTimer(timer);

                timer -= m_DeltaTime;
                yield return new WaitForSeconds(m_DeltaTime);
            }

            TickTimer(0f);
		}


        protected abstract void TickTimer(float timer);
	}

}
