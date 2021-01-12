using Leopotam.Ecs;

namespace Client {
    [EcsInject]
    sealed class ApplyDamageSystem : IEcsRunSystem {
        // Auto-injected fields.
        readonly EcsWorld _world = null;
        readonly EcsFilter<DamageComponent> _damages = null;
        
        void IEcsRunSystem.Run ()
        {
            //UnityEngine.Debug.Log(UnityEngine.Time.frameCount);
            foreach (int id in _damages)
            {
                var damage = _damages.Components1[id];
                UnityEngine.Debug.Log($"set damage {damage.amout}");
            }
        }
    }
}