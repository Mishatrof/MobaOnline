#pragma warning disable 0649
using UnityEngine;

namespace MyAsset
{
    [CreateAssetMenu(menuName ="My Asset/Events/Game Object")]
    public class GameObjectEvent : GameEvent<GameObject>
    { }
}
