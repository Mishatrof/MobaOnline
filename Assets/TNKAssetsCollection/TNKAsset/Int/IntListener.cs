#pragma warning disable 0649
using UnityEngine.Events;
using UnityEngine;

namespace MyAsset
{
    [AddComponentMenu("My Asset/Event/Listeners/Int")]
	public class IntListener : GameEventListener<int, IntEvent, IntUnityEvent>
    { }
}