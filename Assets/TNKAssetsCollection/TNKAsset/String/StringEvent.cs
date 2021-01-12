#pragma warning disable 0649
using UnityEngine;

namespace MyAsset
{
	[CreateAssetMenu(menuName= "My Asset/Events/String")]
	public class StringEvent : GameEvent<string>
    { }
}