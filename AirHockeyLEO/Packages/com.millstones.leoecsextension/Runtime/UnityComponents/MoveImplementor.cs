using UnityEngine;

namespace Millstones.LeoECSExtension.UnityComponents
{
    [RequireComponent(typeof(Rigidbody))]
    public class MoveImplementor : MonoBehaviour, IPositionComponentImplementor, IVelocityComponentImplementor, IImplementor
    {
        public Vector3 Position
        {
            get => _rigidbody.position;
            set => _rigidbody.MovePosition(value);
        }

        public Vector3 Velocity
        {
            get => _rigidbody.velocity;
            set => _rigidbody.velocity = value;
        }


        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }
}