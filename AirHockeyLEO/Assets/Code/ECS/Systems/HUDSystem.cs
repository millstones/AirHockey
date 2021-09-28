using Leopotam.Ecs;
using AirHockey.ECS.Components;
using AirHockey.ECS.UnityComponents;
using Millstones.LeoECSExtension;
using UnityEngine;

namespace AirHockey.ECS.Systems
{
    public class HUDSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly GameObject _uiGameObject;
        
        private EcsWorld _ecsWorld = null;

        private EcsFilter<HUDViewComponent, ScoreComponent> _filter;
        
        public HUDSystem(GameObject uiGameObject)
        {
            _uiGameObject = uiGameObject;
        }
        public void Init()
        {
            _uiGameObject.AddComponent<HUDImplementor>();
            _ecsWorld.NewEntity<HUDEntityDescriptor>(_uiGameObject);
        }

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var hud = ref _filter.Get1(i);
                var score = _filter.Get2(i);

                hud.HUDView.DownPlayerScore = score.DownPlayerScore;
                hud.HUDView.UpPlayerScore = score.UpPlayerScore;
            }
        }


    }
}