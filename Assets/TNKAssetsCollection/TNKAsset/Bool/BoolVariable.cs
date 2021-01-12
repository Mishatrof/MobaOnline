#pragma warning disable 0649
using UnityEngine;

namespace MyAsset
{

	[CreateAssetMenu(menuName="My Asset/Variables/Bool")]
	public class BoolVariable : ScriptableObjectVariable<bool, BoolEvent>
	{ }
}