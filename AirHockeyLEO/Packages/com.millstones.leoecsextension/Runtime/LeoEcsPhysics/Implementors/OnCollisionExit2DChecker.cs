using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Implementors
{
    public class OnCollisionExit2DChecker : MonoBehaviour
    {
        private void OnCollisionExit2D(Collision2D other)
        {
            EcsPhysicsEventsSystem.RegisterCollisionExit2DEvent(gameObject, other.collider, other.relativeVelocity);
        }
    }
}