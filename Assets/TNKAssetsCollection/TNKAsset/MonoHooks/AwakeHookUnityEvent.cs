
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MyAsset
{
    public class AwakeHookUnityEvent : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent m_HookEvent;

        void Awake()
        {
            Debug.Log("init1");
            m_HookEvent.Invoke();
        }
    }
}
