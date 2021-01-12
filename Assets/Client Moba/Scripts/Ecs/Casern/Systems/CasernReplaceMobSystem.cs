using Leopotam.Ecs;

namespace Client {
    [EcsInject]
    sealed class CasernReplaceMobSystem : IEcsRunSystem
    {
        readonly EcsWorld _world = null;
        readonly EcsFilter<CasernReplaceMobEvent> _replaceMobEvents = null;
        readonly EcsFilter<CasernComponent> _caserns = null;

        void IEcsRunSystem.Run ()
        {
            foreach(int id in _replaceMobEvents)
            {
                var replaceEvent = _replaceMobEvents.Components1[id];

                foreach(int idc in _caserns)
                {
                    var casern = _caserns.Components1[idc];

                    if (casern.controller.indexLine != replaceEvent.indexCasern)
                        continue;

                    casern.controller.ReplaceMob(replaceEvent.indexMob);

                    _world.CreateEntityWith(out UIMobIconsPanelChange changeEvent);
                    changeEvent.casernController = casern.controller;

                    break;
                }
            }
        }
    }
}