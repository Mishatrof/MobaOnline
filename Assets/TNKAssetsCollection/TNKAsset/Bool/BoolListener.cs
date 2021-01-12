#pragma warning disable 0649
using UnityEngine.Events;
using UnityEngine;

namespace MyAsset
{
    [AddComponentMenu("My Asset/Event/Listeners/Bool")]
	public class BoolListener : GameEventListener<bool, BoolEvent, BoolUnityEvent>
    { }
}