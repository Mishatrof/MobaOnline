using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAsset
{
    public class StartHook : MonoBehaviour
    {
        [SerializeField]
        private VoidEvent m_HookEvent;

        void Start()
        {
            m_HookEvent?.Raise();
        }
    }
}
