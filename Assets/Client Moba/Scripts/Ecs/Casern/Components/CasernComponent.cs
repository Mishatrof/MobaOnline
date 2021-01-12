using Leopotam.Ecs;

namespace Client
{
    sealed class CasernComponent : IEcsAutoResetComponent
    {
        public ICasernController controller;

        void IEcsAutoResetComponent.Reset()
        {
            controller = null;
        }
    }
}