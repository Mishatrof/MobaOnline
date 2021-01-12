using UnityEngine;


namespace MyAsset.Components
{

	public class ExampleRotateTurret2D : ExampleRotateTurret
	{
        public override float CalculateAngle(Vector3 direction)
        {
            return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }

        public override Quaternion ConvertAngleToQuaternion(float angle)
        {
            return Quaternion.Euler(0f, 0f, angle);
        }


#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.gray;

            if (m_Target)
                Gizmos.DrawLine(transform.position, m_Target.position);

            if (m_UseLimitAngle)
            {
                UnityEditor.Handles.color = Color.green;

                Vector3 from = transform.parent.TransformDirection(Vector3.right);
                UnityEditor.Handles.DrawWireArc(transform.position, transform.forward, from, -m_LimitAngle, 2f);
                UnityEditor.Handles.DrawWireArc(transform.position, transform.forward, from, m_LimitAngle, 2f);
            }
        }
#endif
    }

}
