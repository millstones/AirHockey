using Leopotam.Ecs;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Events
{
    public struct OnEntityTriggerEvent
    {
        public EcsEntity OtherEntity;
        public PhysicsEventType EventType;
    }
}