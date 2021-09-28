using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Events
{
    public struct OnCollisionStayEvent
    {
        public GameObject senderGameObject;
        public Collider collider;
        public ContactPoint firstContactPoint;
        public Vector3 relativeVelocity;
    }
}