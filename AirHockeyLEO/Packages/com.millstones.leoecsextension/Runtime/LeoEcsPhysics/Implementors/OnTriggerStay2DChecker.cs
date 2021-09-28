using Millstones.LeoECSExtension.LeoEcsPhysics.Emitter;
using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Implementors
{
    public class OnTriggerStay2DChecker : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D other)
        { 
            EcsPhysicsEvents.RegisterTriggerStay2DEvent(gameObject, other);
        }
    }
}