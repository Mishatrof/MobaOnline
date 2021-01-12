using UnityEngine;


namespace MyAsset.Components
{
    [AddComponentMenu("My Asset/Components/MouseButtonDown")]
	public class MouseButtonDown : MonoBehaviour
	{
        [SerializeField]
        private int m_KeyMouseButton = 0;
        [SerializeField]
        private VoidEvent m_ButtonDownEvent = null;


		private void Update()
		{
            if (Input.GetMouseButtonDown(m_KeyMouseButton))
                m_ButtonDownEvent.Raise();
        }
	}

}
