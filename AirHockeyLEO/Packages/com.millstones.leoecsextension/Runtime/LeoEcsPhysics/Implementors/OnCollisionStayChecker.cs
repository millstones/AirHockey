using Millstones.LeoECSExtension.LeoEcsPhysics.Emitter;
using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Implementors
{
    public class OnCollisionStayChecker : MonoBehaviour
    {
        private void OnCollisionStay(Collision other)
        {
            EcsPhysicsEvents.RegisterCollisionStayEvent(gameObject, other.collider, other.GetContact(0), other.relativeVelocity);
        }
    }
}