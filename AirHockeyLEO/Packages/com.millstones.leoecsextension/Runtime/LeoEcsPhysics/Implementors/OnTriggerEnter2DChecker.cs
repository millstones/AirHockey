using UnityEngine;

namespace Millstones.LeoECSExtension.LeoEcsPhysics.Implementors
{
    public class OnTriggerEnter2DChecker : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        { 
            EcsPhysicsEventsSystem.RegisterTriggerEnter2DEvent(gameObject, other);
        }
    }
}