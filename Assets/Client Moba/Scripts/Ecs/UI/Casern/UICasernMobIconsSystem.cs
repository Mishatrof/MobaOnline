using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    [EcsInject]
    sealed class UICasernMobIconsSystem : IEcsInitSystem, IEcsRunSystem {
        // Auto-injected fields.
        readonly EcsWorld _world = null;
        readonly EcsFilter<UIMobIconsPanelChange> _mobIconPanelEvent;
        readonly EcsFilter<UIMobIconsPanelComponent> _panels;
        
        void IEcsInitSystem.Initialize ()
        {
            var unityMobIconPanels = GameObject.FindObjectsOfType<UIMobIconInCaserne>();

            foreach(var unityPanel in unityMobIconPanels)
            {
                EcsEntity mobIconPanelEntity = _world.CreateEntity();

                var mobIconPanel = _world.AddComponent<UIMobIconsPanelComponent>(mobIconPanelEntity);
                mobIconPanel.controller = unityPanel;
            }
        }

        void IEcsInitSystem.Destroy () { }

        void IEcsRunSystem.Run()
        {
            if (_mobIconPanelEvent.IsEmpty())
                return;

            var changeEvent = _mobIconPanelEvent.Components1[0];

            foreach(int id in _panels)
            {
                var panel = _panels.Components1[id];

                //panel.controller.UpdateCells(changeEvent.casernController.GetMobIcons());
            }
        }
    }
}