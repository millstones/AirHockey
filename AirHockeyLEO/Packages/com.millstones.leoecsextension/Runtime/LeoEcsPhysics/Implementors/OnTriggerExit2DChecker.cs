using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Implementors
{
    public class OnTriggerExit2DChecker : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D other)
        { 
            EcsPhysicsEventsSystem.RegisterTriggerExit2DEvent(gameObject, other);
        }
    }
}