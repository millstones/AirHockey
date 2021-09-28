using UnityEngine;

namespace Millstones.LeoECSExtension.UnityComponents
{
    public class PositionImplementor : MonoBehaviour, IPositionComponentImplementor, IImplementor
    {
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
    }
}