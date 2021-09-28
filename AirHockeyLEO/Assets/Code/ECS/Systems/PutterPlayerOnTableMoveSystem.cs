using AirHockey.ECS.Services;
using Leopotam.Ecs;
using Millstones.Common;
using Millstones.LeoECSExtension.Components;

namespace AirHockey.ECS.Systems
{
    public class PutterPlayerOnTableMoveSystem : IEcsRunSystem
    {
        private const int SPEED_MULTIPLIER = 10; // TODO:
        
        private EcsFilter<PlayerTag, OnTableTag, MoveViewComponent> _filter;

        private EcsWorld _ecsWorld;
        
        public void Run()
        {
            var inputService = Service<InputService>.Get();
            
            if (!inputService.IsLeftMouseButtonDown) return;
            
            foreach (var i in _filter)
            {
                //var filterEntity = _filter.GetEntity(i);
                var hitInfo = inputService.GetMouseHitInfo(_ecsWorld);

                //if (filterEntity.Equals(hitInfo.EntityIdMouseHit))
                {
                    
                }
                
                ref var moveComponent = ref _filter.Get3(i);
                    
                moveComponent.VelocityView.Velocity = SPEED_MULTIPLIER * (hitInfo.HitPoint - moveComponent.PositionView.Position);
            }
            
        }
    }
}