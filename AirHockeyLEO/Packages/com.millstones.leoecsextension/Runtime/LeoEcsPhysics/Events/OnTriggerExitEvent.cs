using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Events
{
    public struct OnTriggerExitEvent
    {
        public GameObject senderGameObject;
        public Collider collider;
    }
}