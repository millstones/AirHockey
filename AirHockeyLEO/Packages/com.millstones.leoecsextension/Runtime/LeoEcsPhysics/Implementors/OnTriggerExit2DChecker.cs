using Millstones.LeoECSExtension.LeoEcsPhysics.Emitter;
using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Implementors
{
    public class OnTriggerExit2DChecker : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D other)
        { 
            EcsPhysicsEvents.RegisterTriggerExit2DEvent(gameObject, other);
        }
    }
}