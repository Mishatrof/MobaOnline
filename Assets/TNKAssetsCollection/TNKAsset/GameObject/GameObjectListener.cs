using UnityEngine;

namespace MyAsset
{
    [AddComponentMenu("My Asset/Event/Listeners/Game Object")]
    public class GameObjectListener : GameEventListener<GameObject, GameObjectEvent, GameObjectUnityEvent>
    { }
}