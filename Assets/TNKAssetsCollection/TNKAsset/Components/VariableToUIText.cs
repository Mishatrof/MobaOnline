using UnityEngine.UI;
using UnityEngine;


namespace MySpace
{

    [AddComponentMenu("My Asset/Components/VariableToUIText")]
    public class VariableToUIText : MonoBehaviour
	{
        [SerializeField]
        private Text m_Text = null;
        [SerializeField]
        private ScriptableObject m_Variable;


        public void OnChangeValue()
        {
            m_Text.text = m_Variable.ToString();
        }


        public void SetText(float value)
        {
            m_Text.text = value.ToString("0.0");
        }


        public void SetText(int value)
        {
            m_Text.text = value.ToString();
        }


        public void SetText(string value)
        {
            m_Text.text = value;
        }


        private void FixedUpdate()
        {
            if (m_Variable)
                m_Text.text = m_Variable.ToString();
        }
    }

}
