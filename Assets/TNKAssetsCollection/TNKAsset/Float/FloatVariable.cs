#pragma warning disable 0649
using UnityEngine;

namespace MyAsset
{

	[CreateAssetMenu(menuName="My Asset/Variables/Float")]
	public class FloatVariable : ScriptableObjectVariable<float, FloatEvent>
	{
        public void SetValue(FloatVariable variable)
        {
            base.SetValue(variable);
        }
    }
}