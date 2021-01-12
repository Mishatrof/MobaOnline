using UnityEngine;


namespace MyAsset.Extensions
{

	public static class QuaternionExtension
    {
        public static Quaternion LookRotation2D(Vector2 from, Vector2 to)
        {
            Vector2 dirToTarget = to - from;

            float angle = Vector2.Angle(Vector2.right, dirToTarget);
            angle = to.y < from.y ? -angle : angle;

            return Quaternion.Euler(0f, 0f, angle);
        }
	}

}
