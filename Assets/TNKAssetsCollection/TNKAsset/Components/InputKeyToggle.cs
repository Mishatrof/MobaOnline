using UnityEngine;

namespace MyAsset.Components
{

	public class InputKeyToggle : MonoBehaviour
	{
        [SerializeField]
        private KeyCode m_Key = KeyCode.A;

        [SerializeField]
        private BoolEvent m_PressedKeyEvent = null;

        private void CheckPressedButton(KeyCode button, BoolEvent inputEvent)
		{
            if (Input.GetKeyDown(button) && inputEvent)
                inputEvent.Raise(true);
            else if (Input.GetKeyUp(button) && inputEvent)
                inputEvent.Raise(false);
        }

		private void Update()
		{
            CheckPressedButton(m_Key, m_PressedKeyEvent);
        }
	}

}
