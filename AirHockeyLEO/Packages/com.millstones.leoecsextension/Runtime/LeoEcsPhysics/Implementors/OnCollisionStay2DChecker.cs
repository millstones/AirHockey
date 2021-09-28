using Millstones.LeoECSExtension.LeoEcsPhysics.Emitter;
using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Implementors
{
    public class OnCollisionStay2DChecker : MonoBehaviour
    {
        private void OnCollisionStay2D(Collision2D other)
        {
            EcsPhysicsEvents.RegisterCollisionStay2DEvent(gameObject, other.collider, other.GetContact(0), other.relativeVelocity);
        }
    }
}