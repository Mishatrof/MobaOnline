using UnityEngine;

namespace MyAsset
{
    [AddComponentMenu("My Asset/Event/Listeners/String")]
	public class StringListener : GameEventListener<string, StringEvent, StringUnityEvent>
    { }
}