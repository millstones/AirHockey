﻿using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Events
{
    public struct OnCollisionExit2DEvent
    {
        public GameObject senderGameObject;
        public Collider2D collider2D;
        public Vector2 relativeVelocity;
    }
}