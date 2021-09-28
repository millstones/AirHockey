using AirHockey.Unity;
using Leopotam.Ecs;
using Millstones.LeoECSExtension;
using Millstones.LeoECSExtension.LeoEcsPhysics.Implementors;
using Millstones.LeoECSExtension.UnityComponents;

namespace AirHockey.ECS.Systems
{
    public class TableSpawnSystem : IEcsInitSystem
    {
        private readonly ITableService _tableService;
        readonly EcsWorld _world = null;
        
        
        
        public TableSpawnSystem(ITableService tableService)
        {
            _tableService = tableService;
        }
        
        public void Init()
        {
            var plane = _tableService.TablePositions.Plane;
            var gateUp = _tableService.TablePositions.UpGate;
            var gateDown = _tableService.TablePositions.DownGate;

            plane.AddComponent<OnCollisionEnterChecker>();
            plane.AddComponent<EntityReferenceImplementor>();
            _world.NewEntity<TableEntityDescriptor>(plane);
            
            gateUp.AddComponent<OnTriggerEnterChecker>();
            gateUp.AddComponent<EntityReferenceImplementor>();
            _world.NewEntity<GateUpEntityDescriptor>(gateUp);
            
            gateDown.AddComponent<OnTriggerEnterChecker>();
            gateDown.AddComponent<EntityReferenceImplementor>();
            _world.NewEntity<GateDownEntityDescriptor>(gateDown);
        }
    }
}