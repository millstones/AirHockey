using Leopotam.Ecs;
using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Events
{
    public struct OnEntityCollisionEvent
    {
        public EcsEntity OtherEntity;
        public PhysicsEventType EventType;
        public ContactPoint FirstContactPoint;
        public Vector3 RelativeVelocity;
    }
}