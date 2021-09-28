using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Implementors
{
    public class OnCollisionEnter2DChecker : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            EcsPhysicsEventsSystem.RegisterCollisionEnter2DEvent(gameObject, other.collider, other.GetContact(0), other.relativeVelocity);
        }
    }
}