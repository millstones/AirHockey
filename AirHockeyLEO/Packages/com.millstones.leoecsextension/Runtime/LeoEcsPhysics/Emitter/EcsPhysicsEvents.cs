using Leopotam.Ecs;
using Millstones.LeoECSExtension.LeoEcsPhysics.Events;
using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Emitter
{
    public class EcsPhysicsEvents
    {
        readonly EcsWorld _ecsWorld;

        public EcsPhysicsEvents(EcsWorld world)
        {
            _ecsWorld = world;
        }
        
        public void RegisterTriggerEnterEvent(GameObject senderGameObject, Collider collider)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnTriggerEnterEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider = collider;
        }

        public void RegisterTriggerStayEvent(GameObject senderGameObject, Collider collider)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnTriggerStayEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider = collider;
        }

        public void RegisterTriggerExitEvent(GameObject senderGameObject, Collider collider)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnTriggerExitEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider = collider;
        }

        public void RegisterCollisionEnterEvent(GameObject senderGameObject, Collider collider, ContactPoint firstContactPoint, Vector3 relativeVelocity)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnCollisionEnterEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider = collider;
            eventComponent.firstContactPoint = firstContactPoint;
            eventComponent.relativeVelocity = relativeVelocity;
        }

        public void RegisterCollisionStayEvent(GameObject senderGameObject, Collider collider, ContactPoint firstContactPoint, Vector3 relativeVelocity)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnCollisionStayEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider = collider;
            eventComponent.firstContactPoint = firstContactPoint;
            eventComponent.relativeVelocity = relativeVelocity;
        }

        public void RegisterCollisionExitEvent(GameObject senderGameObject, Collider collider, Vector3 relativeVelocity)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnCollisionExitEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider = collider;
            eventComponent.relativeVelocity = relativeVelocity;
        }

        public void RegisterControllerColliderHitEvent(GameObject senderGameObject, Collider collider, Vector3 hitNormal, Vector3 moveDirection)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnControllerColliderHitEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider = collider;
            eventComponent.hitNormal = hitNormal;
            eventComponent.moveDirection = moveDirection;
        }
        
        public void RegisterCollisionEnter2DEvent(GameObject senderGameObject, Collider2D collider2D, ContactPoint2D firstContactPoint2D, Vector2 relativeVelocity)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnCollisionEnter2DEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider2D = collider2D;
            eventComponent.firstContactPoint2D = firstContactPoint2D;
            eventComponent.relativeVelocity = relativeVelocity;
        }
        
        public void RegisterCollisionStay2DEvent(GameObject senderGameObject, Collider2D collider2D, ContactPoint2D firstContactPoint2D, Vector2 relativeVelocity)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnCollisionStay2DEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider2D = collider2D;
            eventComponent.firstContactPoint2D = firstContactPoint2D;
            eventComponent.relativeVelocity = relativeVelocity;
        }
        
        public void RegisterCollisionExit2DEvent(GameObject senderGameObject, Collider2D collider2D, Vector2 relativeVelocity)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnCollisionExit2DEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider2D = collider2D;
            eventComponent.relativeVelocity = relativeVelocity;
        }
        
        public void RegisterTriggerEnter2DEvent(GameObject senderGameObject, Collider2D collider2D)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnTriggerEnter2DEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider2D = collider2D;
        }
        
        public void RegisterTriggerStay2DEvent(GameObject senderGameObject, Collider2D collider2D)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnTriggerStay2DEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider2D = collider2D;
        }
        
        public void RegisterTriggerExit2DEvent(GameObject senderGameObject, Collider2D collider2D)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnTriggerExit2DEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider2D = collider2D;
        }
    }
}