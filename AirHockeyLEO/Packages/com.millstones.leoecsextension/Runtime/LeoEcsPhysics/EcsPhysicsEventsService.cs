using Leopotam.Ecs;
using Millstones.LeoECSExtension.LeoEcsPhysics.Emitter;

namespace Millstones.LeoECSExtension.LeoEcsPhysics
{
    public static class EcsPhysicsEventsService
    {
        private static EcsPhysicsEvents _ecsPhysicsEvents;
        public static EcsPhysicsEvents Get(EcsWorld world)
        {
            return _ecsPhysicsEvents ??= new EcsPhysicsEvents(world);
        }
    }
}