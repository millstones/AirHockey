using Leopotam.Ecs;
using Millstones.LeoECSExtension.LeoEcsPhysics.Events;
using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics
{
    public class EcsPhysicsEventsSystem
    {
        private static EcsWorld _ecsWorld;

        private readonly EcsSystems _ecsSystems;
        public EcsPhysicsEventsSystem(EcsWorld world)
        {
            _ecsWorld = world;
            _ecsSystems = new EcsSystems(_ecsWorld, nameof(EcsPhysicsEventsSystem));
            
            _ecsSystems
                .OneFrame<OnTriggerEnterEvent>()
                .OneFrame<OnTriggerStayEvent>()
                .OneFrame<OnTriggerExitEvent>()
                
                .OneFrame<OnTriggerEnter2DEvent>()
                .OneFrame<OnTriggerStay2DEvent>()
                .OneFrame<OnTriggerExit2DEvent>()
                
                .OneFrame<OnCollisionEnterEvent>()
                .OneFrame<OnCollisionStayEvent>()
                .OneFrame<OnCollisionExitEvent>()
                
                .OneFrame<OnCollisionEnter2DEvent>()
                .OneFrame<OnCollisionStay2DEvent>()
                .OneFrame<OnCollisionExit2DEvent>()
                
                .OneFrame<OnControllerColliderHitEvent>()
                
                .OneFrame<OnEntityTriggerEvent>()
                .OneFrame<OnEntityCollisionEvent>()
                .OneFrame<OnEntityCollision2DEvent>()
                .OneFrame<OnEntityControllerColliderHitEvent>()
                
                .Init();
        }

        public void FixedUpdate()
        {
            _ecsSystems?.Run();
        }
        
        public static void RegisterTriggerEnterEvent(GameObject senderGameObject, Collider collider)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnTriggerEnterEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider = collider;
            
            TryBroadcastEntityTriggerEvent(senderGameObject, collider, PhysicsEventType.Enter);
        }

        public static void RegisterTriggerStayEvent(GameObject senderGameObject, Collider collider)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnTriggerStayEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider = collider;
            
            TryBroadcastEntityTriggerEvent(senderGameObject, collider, PhysicsEventType.Stay);
        }

        public static void RegisterTriggerExitEvent(GameObject senderGameObject, Collider collider)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnTriggerExitEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider = collider;

            TryBroadcastEntityTriggerEvent(senderGameObject, collider, PhysicsEventType.Exit);
        }

        private static void TryBroadcastEntityTriggerEvent(GameObject senderGameObject, Collider collider, PhysicsEventType type)
        {
            if (!_ecsWorld.TryGetEntityByGameObject(senderGameObject, out var sander)) return;
            if (!_ecsWorld.TryGetEntityByGameObject(collider.gameObject, out var other)) return;

            sander.Get<OnEntityTriggerEvent>() = new OnEntityTriggerEvent() {EventType = type, OtherEntity = other};
            other.Get<OnEntityTriggerEvent>() = new OnEntityTriggerEvent() {EventType = type, OtherEntity = sander};
        }

        public static void RegisterCollisionEnterEvent(GameObject senderGameObject, Collider collider, ContactPoint firstContactPoint, Vector3 relativeVelocity)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnCollisionEnterEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider = collider;
            eventComponent.firstContactPoint = firstContactPoint;
            eventComponent.relativeVelocity = relativeVelocity;
            
            TryBroadcastEntityCollisionEvent(senderGameObject, collider, firstContactPoint, relativeVelocity, PhysicsEventType.Enter);
        }

        public static void RegisterCollisionStayEvent(GameObject senderGameObject, Collider collider, ContactPoint firstContactPoint, Vector3 relativeVelocity)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnCollisionStayEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider = collider;
            eventComponent.firstContactPoint = firstContactPoint;
            eventComponent.relativeVelocity = relativeVelocity;
            
            TryBroadcastEntityCollisionEvent(senderGameObject, collider, firstContactPoint, relativeVelocity, PhysicsEventType.Stay);
        }

        public static void RegisterCollisionExitEvent(GameObject senderGameObject, Collider collider, Vector3 relativeVelocity)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnCollisionExitEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider = collider;
            eventComponent.relativeVelocity = relativeVelocity;

            TryBroadcastEntityCollisionEvent(senderGameObject, collider, new ContactPoint(), relativeVelocity, PhysicsEventType.Exit);
        }

        private static void TryBroadcastEntityCollisionEvent(GameObject senderGameObject, Collider collider, 
            ContactPoint firstContactPoint, Vector3 relativeVelocity, PhysicsEventType type)
        {
            if (!_ecsWorld.TryGetEntityByGameObject(senderGameObject.gameObject, out var sander)) return;
            if (!_ecsWorld.TryGetEntityByGameObject(collider.gameObject, out var other)) return;

            sander.Get<OnEntityCollisionEvent>() = new OnEntityCollisionEvent(){EventType = type, OtherEntity = other, FirstContactPoint = firstContactPoint, RelativeVelocity = relativeVelocity};
            other.Get<OnEntityCollisionEvent>() = new OnEntityCollisionEvent() {EventType = type, OtherEntity = sander, FirstContactPoint = firstContactPoint, RelativeVelocity = relativeVelocity};
        }

        public static void RegisterControllerColliderHitEvent(GameObject senderGameObject, Collider collider, Vector3 hitNormal, Vector3 moveDirection)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnControllerColliderHitEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider = collider;
            eventComponent.hitNormal = hitNormal;
            eventComponent.moveDirection = moveDirection;
            
            if (!_ecsWorld.TryGetEntityByGameObject(senderGameObject.gameObject, out var sander)) return;
            if (!_ecsWorld.TryGetEntityByGameObject(collider.gameObject, out var other)) return;

            sander.Get<OnEntityControllerColliderHitEvent>() = new OnEntityControllerColliderHitEvent(){OtherEntity = other, HitNormal = hitNormal, MoveDirection = moveDirection};
            other.Get<OnEntityControllerColliderHitEvent>() = new OnEntityControllerColliderHitEvent() {OtherEntity = sander, HitNormal = hitNormal, MoveDirection = moveDirection};
        }
        
        public static void RegisterCollisionEnter2DEvent(GameObject senderGameObject, Collider2D collider2D, ContactPoint2D firstContactPoint2D, Vector2 relativeVelocity)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnCollisionEnter2DEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider2D = collider2D;
            eventComponent.firstContactPoint2D = firstContactPoint2D;
            eventComponent.relativeVelocity = relativeVelocity;
            
            TryBroadcastEntityCollisionEvent(senderGameObject, collider2D, firstContactPoint2D, relativeVelocity, PhysicsEventType.Enter);
        }
        
        public static void RegisterCollisionStay2DEvent(GameObject senderGameObject, Collider2D collider2D, ContactPoint2D firstContactPoint2D, Vector2 relativeVelocity)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnCollisionStay2DEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider2D = collider2D;
            eventComponent.firstContactPoint2D = firstContactPoint2D;
            eventComponent.relativeVelocity = relativeVelocity;
            
            TryBroadcastEntityCollisionEvent(senderGameObject, collider2D, firstContactPoint2D, relativeVelocity, PhysicsEventType.Stay);
        }
        
        public static void RegisterCollisionExit2DEvent(GameObject senderGameObject, Collider2D collider2D, Vector2 relativeVelocity)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnCollisionExit2DEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider2D = collider2D;
            eventComponent.relativeVelocity = relativeVelocity;
            
            TryBroadcastEntityCollisionEvent(senderGameObject, collider2D, new ContactPoint2D(), relativeVelocity, PhysicsEventType.Exit);
        }
        
        private static void TryBroadcastEntityCollisionEvent(GameObject senderGameObject, Collider2D collider, 
            ContactPoint2D firstContactPoint, Vector2 relativeVelocity, PhysicsEventType type)
        {
            if (!_ecsWorld.TryGetEntityByGameObject(senderGameObject.gameObject, out var sander)) return;
            if (!_ecsWorld.TryGetEntityByGameObject(collider.gameObject, out var other)) return;

            sander.Get<OnEntityCollision2DEvent>() = new OnEntityCollision2DEvent(){EventType = type, OtherEntity = other, FirstContactPoint = firstContactPoint, RelativeVelocity = relativeVelocity};
            other.Get<OnEntityCollision2DEvent>() = new OnEntityCollision2DEvent();
        }
        
        public static void RegisterTriggerEnter2DEvent(GameObject senderGameObject, Collider2D collider2D)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnTriggerEnter2DEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider2D = collider2D;
            
            TryBroadcastEntityTriggerEvent(senderGameObject, collider2D, PhysicsEventType.Enter);
        }
        
        public static void RegisterTriggerStay2DEvent(GameObject senderGameObject, Collider2D collider2D)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnTriggerStay2DEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider2D = collider2D;
            
            TryBroadcastEntityTriggerEvent(senderGameObject, collider2D, PhysicsEventType.Stay);
        }
        
        public static void RegisterTriggerExit2DEvent(GameObject senderGameObject, Collider2D collider2D)
        {
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnTriggerExit2DEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider2D = collider2D;
            
            TryBroadcastEntityTriggerEvent(senderGameObject, collider2D, PhysicsEventType.Exit);
        }
        
        private static void TryBroadcastEntityTriggerEvent(GameObject senderGameObject, Collider2D collider, PhysicsEventType type)
        {
            if (!_ecsWorld.TryGetEntityByGameObject(senderGameObject, out var sander)) return;
            if (!_ecsWorld.TryGetEntityByGameObject(collider.gameObject, out var other)) return;

            sander.Get<OnEntityTriggerEvent>() = new OnEntityTriggerEvent() {EventType = type, OtherEntity = other};
            other.Get<OnEntityTriggerEvent>() = new OnEntityTriggerEvent() {EventType = type, OtherEntity = sander};
        }
    }
}