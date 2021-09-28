using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Implementors
{
    public class OnCollisionExitChecker : MonoBehaviour
    {
        private void OnCollisionExit(Collision other)
        {
            EcsPhysicsEventsSystem.RegisterCollisionExitEvent(gameObject, other.collider, other.relativeVelocity);
        }
    }
}