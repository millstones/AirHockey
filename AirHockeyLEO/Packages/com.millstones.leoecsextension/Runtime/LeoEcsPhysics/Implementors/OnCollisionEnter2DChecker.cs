using Millstones.LeoECSExtension.LeoEcsPhysics.Emitter;
using Millstones.LeoECSExtension.LeoEcsPhysics.Events;
using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Implementors
{
    public class OnCollisionEnter2DChecker : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            EcsPhysicsEvents.RegisterCollisionEnter2DEvent(gameObject, other.collider, other.GetContact(0), other.relativeVelocity);
            
            var eventEntity = _ecsWorld.NewEntity();
            ref var eventComponent = ref eventEntity.Get<OnCollisionEnter2DEvent>();
            eventComponent.senderGameObject = senderGameObject;
            eventComponent.collider2D = GetComponent<Collider2D>();
            eventComponent.firstContactPoint2D = firstContactPoint2D;
            eventComponent.relativeVelocity = relativeVelocity;
            
        }
    }
}