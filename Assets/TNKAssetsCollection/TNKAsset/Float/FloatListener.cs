#pragma warning disable 0649
using UnityEngine.Events;
using UnityEngine;

namespace MyAsset
{
    [AddComponentMenu("My Asset/Event/Listeners/Float")]
	public class FloatListener : GameEventListener<float, FloatEvent, FloatUnityEvent>
    { }
}