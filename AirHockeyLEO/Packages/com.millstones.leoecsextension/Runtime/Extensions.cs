using System.Linq;
using Leopotam.Ecs;
using Millstones.LeoECSExtension.UnityComponents;
using UnityEngine;

namespace Millstones.LeoECSExtension
{
    public static class Extensions
    {
        private static bool TryGetEntityById(this EcsWorld ecsWorld, int id, out EcsEntity entity)
        {
            entity = EcsEntity.Null;
            var allEntity = new EcsEntity[100];
            ecsWorld.GetAllEntities(ref allEntity);
            entity = allEntity.First(x => x.GetInternalId() == id);

            return (entity != null && entity != EcsEntity.Null);
        }
        
        public static bool TryGetEntityByGameObject(this EcsWorld ecsWorld, GameObject gameObject, out EcsEntity entity)
        {
            entity = EcsEntity.Null;
            //gameObject.transform.is
            var eri = gameObject.GetComponent <IEntityReferenceComponentImplementor>();
            return eri != null && ecsWorld.TryGetEntityById(eri.EntityId, out entity);
        }

        public static EcsEntity NewEntity<T>(this EcsWorld world, GameObject gameObject, IImplementor[] implementors) where T : EntityDescriptor, new()
        {
            var retVal = world.NewEntity();

            var descriptor = new T();
            descriptor.PrepareEntity(ref retVal, implementors);
            
            var eri = 
                gameObject.GetComponent<IEntityReferenceComponentImplementor>() ?? 
                gameObject.AddComponent<EntityReferenceImplementor>();
            eri.EntityId = retVal.GetInternalId();
            
            return retVal;
        }
        
        public static EcsEntity NewEntity<T>(this EcsWorld world, GameObject gameObject) where T : EntityDescriptor, new()
        {
            var retVal = world.NewEntity();

            var descriptor = new T();
            descriptor.PrepareEntity(ref retVal, gameObject.GetComponentsInChildren<IImplementor>(true));
            
            var eri = 
                gameObject.GetComponent<IEntityReferenceComponentImplementor>() ??
                gameObject.AddComponent<EntityReferenceImplementor>();
            eri.EntityId = retVal.GetInternalId();
            
            return retVal;
        }

        public static EcsEntity NewEntity<T>(this EcsWorld world) where T : EntityDescriptor, new()
        {
            var retVal = world.NewEntity();

            var descriptor = new T();
            descriptor.PrepareEntity(ref retVal);

            return retVal;
        }
    }
}