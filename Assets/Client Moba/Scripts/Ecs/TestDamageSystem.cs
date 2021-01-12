using Leopotam.Ecs;

namespace Client {
    [EcsInject]
    sealed class TestDamageSystem : IEcsRunSystem {
        // Auto-injected fields.
        readonly EcsWorld _world = null;
        readonly EcsFilter<DamageComponent> _dfilter;
        readonly EcsFilter<MobComponent> _mfilter;

        void IEcsRunSystem.Run ()
        {
            //UnityEngine.Debug.Log($"{UnityEngine.Time.frameCount} d{_dfilter.GetEntitiesCount()} m{_mfilter.GetEntitiesCount()}");
        }
    }
}