using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    public sealed class EcsStartup : MonoBehaviour {
        public EcsWorld _world;
        EcsSystems _systems;

        void OnEnable () {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                // Register your systems here, for example:
                .Add (new MessageSystem())
                .Initialize ();
        }

        void Update () {
            _world.ProcessDelayedUpdates();
            _systems.Run ();
            // Optional: One-frame components cleanup.
            _world.RemoveOneFrameComponents();
        }

        void OnDisable () {
            _systems.Dispose ();
            _systems = null;
            _world.Dispose ();
            _world = null;
        }
    }
}