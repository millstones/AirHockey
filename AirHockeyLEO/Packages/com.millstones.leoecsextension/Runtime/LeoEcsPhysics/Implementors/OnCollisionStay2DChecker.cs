using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Implementors
{
    public class OnCollisionStay2DChecker : MonoBehaviour
    {
        private void OnCollisionStay2D(Collision2D other)
        {
            EcsPhysicsEventsSystem.RegisterCollisionStay2DEvent(gameObject, other.collider, other.GetContact(0), other.relativeVelocity);
        }
    }
}