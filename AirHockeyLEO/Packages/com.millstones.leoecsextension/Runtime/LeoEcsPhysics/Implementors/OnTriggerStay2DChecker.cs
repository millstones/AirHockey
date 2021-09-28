using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Implementors
{
    public class OnTriggerStay2DChecker : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D other)
        { 
            EcsPhysicsEventsSystem.RegisterTriggerStay2DEvent(gameObject, other);
        }
    }
}