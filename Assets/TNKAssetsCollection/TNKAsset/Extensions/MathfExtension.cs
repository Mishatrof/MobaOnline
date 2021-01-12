using UnityEngine;


namespace MyAsset.Extensions
{

	public static class MathfExtension
	{
        public static float ClampAngle(float angle, float from, float to)
        {
            if (angle > 180)
                angle = 360 - angle;

            angle = Mathf.Clamp(angle, from, to);

            if (angle < 0)
                angle = 360 + angle;

            return angle;
        }
	}

}
