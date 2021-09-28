using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Events
{
    public struct OnCollisionExitEvent
    {
        public GameObject senderGameObject;
        public Collider collider;
        public Vector3 relativeVelocity;
    }
}