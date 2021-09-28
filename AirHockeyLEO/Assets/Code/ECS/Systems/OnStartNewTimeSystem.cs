using AirHockey.ECS.Components;
using AirHockey.ECS.Services;
using Leopotam.Ecs;
using Millstones.LeoECSExtension.LeoEcsPhysics;

namespace AirHockey.ECS.Systems
{
    public class OnStartNewTimeSystem : IEcsRunSystem
    {
        private EcsFilter<GateTag, PhysicsEventsService.PhysicsEventsData> _gateFilter;
        private EcsFilter<OnTableTag> _onTableFilter;
        public void Run()
        {
            foreach (var i in _gateFilter)
            {
                if (_gateFilter.Get2(i).OtherEntity.Has<PuckTag>())
                {

                    foreach (var j in _onTableFilter)
                    {
                        ref var entityOnTable = ref _onTableFilter.GetEntity(j);
                        entityOnTable.Get<OnStartNewTimeEvent>();
                    }
                }
            }
            
        }
    }
}