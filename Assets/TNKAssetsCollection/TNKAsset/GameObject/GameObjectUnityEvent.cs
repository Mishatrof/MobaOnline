#pragma warning disable 0649
using UnityEngine.Events;
using UnityEngine;

namespace MyAsset
{
    [System.Serializable]
    public class GameObjectUnityEvent : UnityEvent<GameObject>
    { }
}