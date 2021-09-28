using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Events
{
    public struct OnTriggerEnter2DEvent
    {
        public GameObject senderGameObject;
        public Collider2D collider2D;
    }
}