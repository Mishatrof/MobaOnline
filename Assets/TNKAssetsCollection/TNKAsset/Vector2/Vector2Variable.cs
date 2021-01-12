#pragma warning disable 0649
using UnityEngine;

namespace MyAsset
{

	[CreateAssetMenu(menuName="My Asset/Variables/Vector2")]
	public class Vector2Variable : ScriptableObjectVariable<Vector2, Vector2Event>
	{ }
}