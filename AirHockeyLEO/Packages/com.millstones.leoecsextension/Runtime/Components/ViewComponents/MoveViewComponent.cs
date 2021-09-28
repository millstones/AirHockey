using Millstones.LeoECSExtension.UnityComponents;

namespace Millstones.LeoECSExtension.Components
{
    public struct MoveViewComponent
    {
        public IPositionComponentImplementor PositionView;
        public IVelocityComponentImplementor VelocityView;
    }
}