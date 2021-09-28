using AirHockey.ECS.Components;
using AirHockey.ECS.Services;
using Leopotam.Ecs;
using Millstones.LeoECSExtension.LeoEcsPhysics;

namespace AirHockey.ECS.Systems
{
    public class GoalDetectorSystem : IEcsRunSystem
    {
        private EcsFilter<PuckTag, PhysicsEventsService.PhysicsEventsData> _puckFilter;
        private EcsFilter<ScoreComponent> _scoreFilter;

        private EcsWorld _ecsWorld;
        
        public void Run()
        {
            foreach (var i in _puckFilter)
            {
                var entity = _puckFilter.Get2(i);

                foreach (var j in _scoreFilter)
                {
                    ref var scoreComponent = ref _scoreFilter.Get1(j);
                    
                    if (entity.OtherEntity.Has<GateUpTag>())
                    {
                        scoreComponent.UpPlayerScore += 1;
                    }
                    else if (entity.OtherEntity.Has<GateDownTag>())
                    {
                        scoreComponent.DownPlayerScore += 1;
                    }
                }
            }
        }
    }
}