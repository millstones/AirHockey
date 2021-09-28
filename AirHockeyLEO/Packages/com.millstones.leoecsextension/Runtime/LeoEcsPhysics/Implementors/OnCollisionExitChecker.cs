using Millstones.LeoECSExtension.LeoEcsPhysics.Emitter;
using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Implementors
{
    public class OnCollisionExitChecker : MonoBehaviour
    {
        private void OnCollisionExit(Collision other)
        {
            EcsPhysicsEvents.RegisterCollisionExitEvent(gameObject, other.collider, other.relativeVelocity);
        }
    }
}