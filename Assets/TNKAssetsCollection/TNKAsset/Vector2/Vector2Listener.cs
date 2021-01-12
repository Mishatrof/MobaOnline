#pragma warning disable 0649
using UnityEngine.Events;
using UnityEngine;

namespace MyAsset
{
    [AddComponentMenu("My Asset/Event/Listeners/Vector2")]
	public class Vector2Listener : GameEventListener<Vector2, Vector2Event, Vector2UnityEvent>
    { }
}