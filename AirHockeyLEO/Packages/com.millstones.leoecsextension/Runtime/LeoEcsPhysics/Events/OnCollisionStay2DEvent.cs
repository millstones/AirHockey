﻿using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Events
{
    public struct OnCollisionStay2DEvent
    {
        public GameObject senderGameObject;
        public Collider2D collider2D;
        public ContactPoint2D firstContactPoint2D;
        public Vector2 relativeVelocity;
    }
}