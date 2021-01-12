using UnityEngine;

namespace MyAsset
{

	[CreateAssetMenu(menuName="My Asset/Variables/Int")]
	public class IntVariable : ScriptableObjectVariable<int, IntEvent>
	{
        public void SetValue(IntVariable variable)
        {
            base.SetValue(variable);
        }
    }
}