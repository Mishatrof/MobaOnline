using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class Test1Startup : MonoBehaviour {
        EcsWorld _world;
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
                .Add (new MobInitSystem())

                //.Add(new TestDamageSystem())
                .Add (new ApplyDamageSystem())
                .Initialize ();
        }

        void Update () {
            _systems.Run();
            //print(Time.frameCount + " remove ");
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