using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Events
{
    public struct OnTriggerExit2DEvent
    {
        public GameObject senderGameObject;
        public Collider2D collider2D;
    }
}