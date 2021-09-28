using Leopotam.Ecs;
using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Events
{
    public struct OnEntityControllerColliderHitEvent
    {
        public EcsEntity OtherEntity;
        public Vector3 HitNormal;
        public Vector3 MoveDirection;
    }
}