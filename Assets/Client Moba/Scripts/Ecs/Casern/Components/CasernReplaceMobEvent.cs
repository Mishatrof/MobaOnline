using Leopotam.Ecs;

namespace Client
{
    [EcsOneFrame]
    sealed class CasernReplaceMobEvent
    {
        public int indexCasern;
        public int indexMob;
    }
}