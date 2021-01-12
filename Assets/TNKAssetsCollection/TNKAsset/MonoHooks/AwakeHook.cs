using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAsset
{
    public class AwakeHook : MonoBehaviour
    {
        [SerializeField]
        private VoidEvent m_HookEvent;

        void Awake()
        {
            m_HookEvent.Raise();
        }
    }
}
