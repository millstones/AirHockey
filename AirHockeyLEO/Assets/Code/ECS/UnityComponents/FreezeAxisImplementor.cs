using Millstones.LeoECSExtension.UnityComponents;
using UnityEngine;

namespace AirHockey.ECS.UnityComponents
{
    [RequireComponent(typeof(Rigidbody))]
    public class FreezeAxisImplementor : MonoBehaviour, IFreezeAxisViewComponent, IImplementor
    {
        public bool FreezeXPosition
        {
            get => _rigidbody.constraints == RigidbodyConstraints.FreezePositionX;
            set
            {
                if (value)
                    SetFreeze(RigidbodyConstraints.FreezePositionX);
                else
                    ResetFreeze(RigidbodyConstraints.FreezePositionX);
            }
        }

        public bool FreezeYPosition
        {
            get => _rigidbody.constraints == RigidbodyConstraints.FreezePositionY;
            set
            {
                if (value)
                    SetFreeze(RigidbodyConstraints.FreezePositionY);
                else
                    ResetFreeze(RigidbodyConstraints.FreezePositionY);
            }
        }

        public bool FreezeZPosition
        {
            get => _rigidbody.constraints == RigidbodyConstraints.FreezePositionZ;
            set
            {
                if (value)
                    SetFreeze(RigidbodyConstraints.FreezePositionZ);
                else
                    ResetFreeze(RigidbodyConstraints.FreezePositionZ);
            }
        }
        public bool FreezeXRotation 
        { 
            get => _rigidbody.constraints == RigidbodyConstraints.FreezeRotationX;
            set
            {
                if (value)
                    SetFreeze(RigidbodyConstraints.FreezeRotationX);
                else
                    ResetFreeze(RigidbodyConstraints.FreezeRotationX);
            }
        }

        public bool FreezeYRotation
        {
            get => _rigidbody.constraints == RigidbodyConstraints.FreezeRotationY;
            set
            {
                if (value)
                    SetFreeze(RigidbodyConstraints.FreezeRotationY);
                else
                    ResetFreeze(RigidbodyConstraints.FreezeRotationY);
            }
        }

        public bool FreezeZRotation
        {
            get => _rigidbody.constraints == RigidbodyConstraints.FreezeRotationZ;
            set
            {
                if (value)
                    SetFreeze(RigidbodyConstraints.FreezeRotationZ);
                else
                    ResetFreeze(RigidbodyConstraints.FreezeRotationZ);
            }
        }


        private Rigidbody _rigidbody;

        void SetFreeze(RigidbodyConstraints constraints)
        {
            _rigidbody.constraints |= constraints;
        }

        void ResetFreeze(RigidbodyConstraints constraints)
        {
            _rigidbody.constraints &= ~constraints;
        }
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }
}