using Leopotam.Ecs;
using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Events
{
    public struct OnEntityCollision2DEvent
    {
        public EcsEntity OtherEntity;
        public PhysicsEventType EventType;
        public ContactPoint2D FirstContactPoint;
        public Vector2 RelativeVelocity;
    }
}