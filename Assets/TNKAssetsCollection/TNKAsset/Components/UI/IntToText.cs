using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyAsset;

namespace MyAsset.Components.UI
{
    public class IntToText : MonoBehaviour, IVoidEventListener
    {
        public VoidEvent m_ChangedEvent;
        public IntVariable variable;
        public UnityEngine.UI.Text text;


        public void OnEventRaised()
        {
            text.text = variable.ToString();
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
