using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Events
{
    public struct OnTriggerEnterEvent
    {
        public GameObject senderGameObject;
        public Collider collider;
    }
}