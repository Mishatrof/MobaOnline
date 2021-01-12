using UnityEngine;

namespace MyAsset
{
    [CreateAssetMenu(menuName="My Asset/Lists/Game Object")]
    public class GameObjectList : ScriptableObjectList<GameObject, GameObjectEvent>
    { }
}
