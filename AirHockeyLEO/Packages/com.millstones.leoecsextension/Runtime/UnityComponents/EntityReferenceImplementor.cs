using UnityEngine;

namespace Millstones.LeoECSExtension.UnityComponents
{
    public class EntityReferenceImplementor : MonoBehaviour, IEntityReferenceComponentImplementor, IImplementor
    {
        public int EntityId
        {
            get => entityId;
            set => entityId = value;
        }
        [SerializeField] private int entityId;
    }
}