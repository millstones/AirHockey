using AirHockey.ECS.Services;
using Leopotam.Ecs;
using Millstones.LeoECSExtension.LeoEcsPhysics;

namespace AirHockey.ECS.Systems
{
    public class OnTableDetectorSystem : IEcsRunSystem
    {
        private EcsFilter<PhysicsEventsService.PhysicsEventsData>.Exclude<OnTableTag, TableTag>.Exclude<GateTag> _filter;

        private EcsWorld _ecsWorld;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var entity = ref _filter.Get1(i);

                if (entity.OtherEntity.Has<TableTag>())
                {
                    _filter.GetEntity(i).Get<OnTableTag>();
                }
            }
        }
    }
}