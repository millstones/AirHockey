using AirHockey.ECS.Services;
using Leopotam.Ecs;
using Millstones.Common;
using Millstones.LeoECSExtension.Components;

namespace AirHockey.ECS.Systems
{
    public class PutterPlayerOnTableMoveSystem : IEcsRunSystem
    {
        private readonly IInputService _inputService;
        private const int SPEED_MULTIPLIER = 10; // TODO:
        
        private EcsFilter<PlayerTag, OnTableTag, MoveViewComponent> _filter;

        private EcsWorld _ecsWorld;

        public PutterPlayerOnTableMoveSystem(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        public void Run()
        {
           
            if (!_inputService.IsLeftMouseButtonDown) return;
            
            foreach (var i in _filter)
            {
                //var filterEntity = _filter.GetEntity(i);
                var hitInfo = _inputService.GetMouseHitInfo(_ecsWorld);

                //if (filterEntity.Equals(hitInfo.EntityIdMouseHit))
                {
                    
                }
                
                ref var moveComponent = ref _filter.Get3(i);
                    
                moveComponent.VelocityView.Velocity = SPEED_MULTIPLIER * (hitInfo.HitPoint - moveComponent.PositionView.Position);
            }
            
        }
    }
}