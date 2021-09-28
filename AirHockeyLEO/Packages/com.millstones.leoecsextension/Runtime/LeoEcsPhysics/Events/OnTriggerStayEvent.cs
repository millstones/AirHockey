using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Events
{
    public struct OnTriggerStayEvent
    {
        public GameObject senderGameObject;
        public Collider collider;
    }
}