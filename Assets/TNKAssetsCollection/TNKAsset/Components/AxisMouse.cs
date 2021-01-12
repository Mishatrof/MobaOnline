using UnityEngine;
using MyAsset;
using UnityEngine.EventSystems;

namespace MySpace
{

	public class AxisMouse : MonoBehaviour
	{
        [SerializeField]
        private Vector2Event m_DeltaMouseEvent;

        Vector2 m_LastPositon;


        private Vector2 GetMouseDeltaAxis()
        {
            Vector2 currentPosition = Input.mousePosition;
            Vector2 deltaPositon = currentPosition - m_LastPositon;
            m_LastPositon = currentPosition;
            return deltaPositon;
        }

		private void Update()
		{
            float mouseHorAxis = Input.GetAxis("Mouse X");
            float mouseVerAxis = Input.GetAxis("Mouse Y");

            m_DeltaMouseEvent.Raise(new Vector2(mouseHorAxis, mouseVerAxis));
        }
	}

}
