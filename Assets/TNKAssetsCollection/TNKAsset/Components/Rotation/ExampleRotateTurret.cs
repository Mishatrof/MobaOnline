using UnityEngine;


namespace MyAsset.Components
{

	public abstract class ExampleRotateTurret : MonoBehaviour
	{
        [SerializeField]
        protected Transform m_Target = null;
        [SerializeField]
        protected float m_SpeedRotate = 10f;
        [SerializeField]
        protected bool m_UseLimitAngle = false;
        [SerializeField, Range(0f, 180f)]
        protected float m_LimitAngle = 10f;


        //private Quaternion m_LastRotation;
        //private Quaternion m_GoalRotation;

        private float m_LastAngle;
        private float m_GoalAngle;


        public Transform lookTarget
        {
            set { m_Target = value; }
            get { return m_Target; }
        }


        private void FixedUpdate()
        {
            if (m_Target == null)
                return;

            Vector3 dir = m_Target.position - transform.position;
            dir = transform.parent.InverseTransformDirection(dir);

            float angle = CalculateAngle(dir);


            if (m_UseLimitAngle)
                angle = Mathf.Clamp(angle, -m_LimitAngle, m_LimitAngle);


            m_GoalAngle = angle;


            //m_GoalRotation = Quaternion.Euler(0f, 0f, angle);
        }

        private void LateUpdate()
        {
           // m_LastRotation = Quaternion.Slerp(m_LastRotation, m_GoalRotation, m_Smooth * Time.deltaTime);
            //transform.localRotation = m_LastRotation;

            if (m_UseLimitAngle)
                m_LastAngle = Mathf.MoveTowards(m_LastAngle, m_GoalAngle, m_SpeedRotate * Time.deltaTime);
            else
                m_LastAngle = Mathf.MoveTowardsAngle(m_LastAngle, m_GoalAngle, m_SpeedRotate * Time.deltaTime);


            transform.localRotation = ConvertAngleToQuaternion(m_LastAngle);
        }

        public abstract Quaternion ConvertAngleToQuaternion(float angle);
        public abstract float CalculateAngle(Vector3 direction);
    }

}
