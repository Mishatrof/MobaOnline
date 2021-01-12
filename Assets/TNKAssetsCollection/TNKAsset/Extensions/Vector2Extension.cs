using UnityEngine;


namespace MyAsset.Extensions
{

	public static class Vector2Extension
	{
		public static Vector2 AngleToDirection(float angle)
		{
            angle *= Mathf.Deg2Rad;
            return new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
        }
	}

}
