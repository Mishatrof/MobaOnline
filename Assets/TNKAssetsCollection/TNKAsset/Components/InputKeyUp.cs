using UnityEngine;

namespace MyAsset.Components
{
    [AddComponentMenu("My Asset/Components/Input/KeyUp")]
	public class InputKeyUp : MonoBehaviour
	{
        [SerializeField]
        private KeyCode m_Key = KeyCode.A;

        [SerializeField]
        private VoidEvent m_KeyDownEvent = null;

		private void Update()
		{
            if (Input.GetKeyDown(m_Key))
                m_KeyDownEvent.Raise();
        }
	}

}
