using Leopotam.Ecs;
using Millstones.LeoECSExtension.LeoEcsPhysics.Events;

namespace Millstones.LeoECSExtension.LeoEcsPhysics
{
    public class PhysicsEventsService : IEcsRunSystem
    {
        private EcsFilter<OnCollisionEnterEvent> _collisionFilter;
        private EcsFilter<OnTriggerEnterEvent> _triggerFilter;
        
        private readonly EcsWorld _ecsWorld;

        public void Run()
        {
            foreach (var i in _collisionFilter)
            {
                if (!_ecsWorld.TryGetEntityByGameObject(_collisionFilter.Get1(i).senderGameObject.gameObject, out var sander)) continue;
                if (!_ecsWorld.TryGetEntityByGameObject(_collisionFilter.Get1(i).collider.gameObject, out var other)) continue;

                sander.Get<PhysicsEventsData>() = new PhysicsEventsData(other);
                other.Get<PhysicsEventsData>() = new PhysicsEventsData(sander);
            }
            
            foreach (var i in _triggerFilter)
            {
                if (!_ecsWorld.TryGetEntityByGameObject(_triggerFilter.Get1(i).senderGameObject.gameObject, out var sander)) continue;
                if (!_ecsWorld.TryGetEntityByGameObject(_triggerFilter.Get1(i).collider.gameObject, out var other)) continue;

                sander.Get<PhysicsEventsData>() = new PhysicsEventsData(other);
                other.Get<PhysicsEventsData>() = new PhysicsEventsData(sander);
            }

        }

        public readonly struct PhysicsEventsData
        {
            public readonly EcsEntity OtherEntity;

            public PhysicsEventsData(EcsEntity otherEntity)
            {
                OtherEntity = otherEntity;
            }
            
            public static PhysicsEventsData Null => new PhysicsEventsData(EcsEntity.Null);
        }
    }
}