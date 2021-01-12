#pragma warning disable 0649
using UnityEngine.Events;
using UnityEngine;

namespace MyAsset
{
    [AddComponentMenu("My Asset/Event/Listeners/BoolInvert")]
	public class BoolInvertListener : GameEventListener<bool, BoolEvent, BoolUnityEvent>
    {
        public override void OnInvoke(bool arg)
        {
            base.OnInvoke(!arg);
        }
    }
}