using Leopotam.Ecs;

namespace Client {
    sealed class MobComponent : IEcsAutoResetComponent
    {
        public IMobController controller;

        void IEcsAutoResetComponent.Reset()
        {
            controller = null;
        }
    }
}