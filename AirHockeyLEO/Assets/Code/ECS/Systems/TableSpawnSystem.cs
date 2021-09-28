using AirHockey.Unity;
using LeoEcsPhysics;
using Leopotam.Ecs;
using Millstones.Common;
using Millstones.LeoECSExtension;
using Millstones.LeoECSExtension.UnityComponents;

namespace AirHockey.ECS.Systems
{
    public class TableSpawnSystem : IEcsInitSystem
    {
        readonly EcsWorld _world = null;

        public void Init()
        {
            var table = Service<ITableService>.Get();
            
            var plane = table.TablePositions.Plane;
            var gateUp = table.TablePositions.UpGate;
            var gateDown = table.TablePositions.DownGate;

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