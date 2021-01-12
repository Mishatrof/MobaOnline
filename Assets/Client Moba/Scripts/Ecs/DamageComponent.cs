using Leopotam.Ecs;

namespace Client {
    [EcsOneFrame]
    sealed class DamageComponent : IEcsAutoResetComponent
    {
        public int amout;

        void IEcsAutoResetComponent.Reset()
        {
            amout = 0;
        }
    }
}