using Millstones.LeoECSExtension.LeoEcsPhysics.Emitter;
using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Implementors
{
    public class OnCollisionEnterChecker : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            EcsPhysicsEvents.RegisterCollisionEnterEvent(gameObject, other.collider, other.GetContact(0), other.relativeVelocity);
        }
    }
}
