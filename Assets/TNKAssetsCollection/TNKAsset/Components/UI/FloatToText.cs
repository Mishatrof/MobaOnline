using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAsset.Components.UI
{
    public class FloatToText : MonoBehaviour, IVoidEventListener
    {
        public VoidEvent m_ChangedEvent;
        public FloatVariable variable;
        public UnityEngine.UI.Text text;
        public string template = "0.0";


        public void OnEventRaised()
        {
            text.text = variable.value.ToString(template);
        }


        private void OnEnable()
        {
            m_ChangedEvent.AddListener(this);
            OnEventRaised();
        }


        private void OnDisable()
        {
            m_ChangedEvent.RemoveListener(this);
        }
    }
}
