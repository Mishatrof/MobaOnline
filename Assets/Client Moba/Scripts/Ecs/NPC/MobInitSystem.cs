using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    [EcsInject]
    sealed class MobInitSystem : IEcsInitSystem {
        // Auto-injected fields.
        readonly EcsWorld _world = null;
        
        void IEcsInitSystem.Initialize () {
            foreach(var unityComponent in GameObject.FindObjectsOfType<MonoBehaviour>())
            {
                if (!(unityComponent is IMobController))
                    continue;

                var controller = unityComponent as IMobController;

                var mobEntity = _world.CreateEntity();

                var mob = _world.AddComponent<MobComponent>(mobEntity);
                mob.controller = controller;

                foreach (var unityEntity in unityComponent.GetComponents<IEcsInitEntity>())
                    unityEntity.Init(mobEntity, _world);
            }
        }

        void IEcsInitSystem.Destroy () { }
    }
}