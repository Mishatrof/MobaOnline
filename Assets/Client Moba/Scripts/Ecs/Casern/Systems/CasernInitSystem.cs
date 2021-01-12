using UnityEngine;
using Leopotam.Ecs;

namespace Client {
    [EcsInject]
    sealed class CasernInitSystem : IEcsInitSystem
    {
        // Auto-injected fields.
        readonly EcsWorld _world = null;
        
        void IEcsInitSystem.Initialize ()
        {
            var casernGOList = GameObject.FindObjectsOfType<RPGGame.GameBase.GameBase>();

            foreach(var unityCasern in casernGOList)
            {
                EcsEntity casernEntity = _world.CreateEntity();
                
                var casern = _world.AddComponent<CasernComponent>(casernEntity);
                casern.controller = unityCasern.gameObject.GetComponent<ICasernController>();
            }
        }

        void IEcsInitSystem.Destroy () { }
    }
}