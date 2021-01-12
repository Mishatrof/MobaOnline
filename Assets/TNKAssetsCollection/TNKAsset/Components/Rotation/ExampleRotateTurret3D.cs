using UnityEngine;


namespace MyAsset.Components
{

	public class ExampleRotateTurret3D : ExampleRotateTurret
	{
        public override float CalculateAngle(Vector3 direction)
        {
            return Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        }

        public override Quaternion ConvertAngleToQuaternion(float angle)
        {
            return Quaternion.Euler(0f, angle, 0f);
        }


#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.gray;

            if (m_Target)
                Gizmos.DrawLine(transform.position, m_Target.position);

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position - transform.up*2f, transform.position + transform.up*2f);

            if (m_UseLimitAngle)
            {
                Vector3 from = transform.parent.TransformDirection(Vector3.forward);

                UnityEditor.Handles.color = Color.green;
                UnityEditor.Handles.DrawWireArc(transform.position, transform.up, from, -m_LimitAngle, 2f);
                UnityEditor.Handles.DrawWireArc(transform.position, transform.up, from, m_LimitAngle, 2f);
            }
        }
#endif
    }

}
