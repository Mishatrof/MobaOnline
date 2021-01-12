using Leopotam.Ecs;

namespace Client {
    [EcsInject]
    sealed class MessageSystem : IEcsRunSystem
    {
        // Auto-injected fields.
        readonly EcsWorld _world = null;
        readonly EcsFilter<MessageComponent> _messages = null;
        
        void IEcsRunSystem.Run () {
            foreach (int id in _messages)
                UnityEngine.Debug.Log(_messages.Components1[id].value);
        }
    }
}