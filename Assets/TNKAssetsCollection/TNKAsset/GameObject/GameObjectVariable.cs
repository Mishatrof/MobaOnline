#pragma warning disable 0649
using UnityEngine;

namespace MyAsset
{

	[CreateAssetMenu(menuName="My Asset/Variables/Game Object")]
	public class GameObjectVariable : ScriptableObjectVariable<GameObject, GameObjectEvent>
	{ }
}