using UnityEngine;

namespace MyAsset
{

	[CreateAssetMenu(menuName="My Asset/Variables/String")]
	public class StringVariable : ScriptableObjectVariable<string, StringEvent>
	{ }
}