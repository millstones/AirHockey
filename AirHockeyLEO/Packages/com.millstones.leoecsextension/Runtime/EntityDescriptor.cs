using System;
using System.Collections.Generic;
using System.Linq;
using Leopotam.Ecs;
using Millstones.LeoECSExtension.UnityComponents;
using UnityEngine;

namespace Millstones.LeoECSExtension
{
    public abstract class EntityDescriptor
    {
        protected EntityDescriptor()
        {
            CheckComponents();
        }

        void CheckComponents()
        {
            var components = GetComponents();

            foreach (var component in components)
            {

                var fields = component.GetFields()
                    .Where(x=> x.IsPublic)
                    .Where(x=> !x.FieldType.IsPrimitive).ToList();
                
                foreach (var field in fields)
                {
                    if (field.FieldType.IsInterface)
                    {

                    }
                    else
                    if (field.FieldType.Name.Equals(nameof(Vector3)) ||
                        field.FieldType.Name.Equals(nameof(Vector2)))
                    {
                    }
                    else
                        throw new Exception($"Типы данных структуры EntityComponent должны быть простыми или InterfaceImplementor, а не {field.FieldType.Name}");
                }
            }
        }

        public abstract void PrepareEntity(ref EcsEntity entity);

        public abstract void PrepareEntity(ref EcsEntity entity, IImplementor[] implementors);

        protected void PrepareImplementor<T>(ref EcsEntity entity, IImplementor[] implementors) where T : struct
        {
            object component = new T();
            var type = component.GetType();
            var publicFields = type.GetFields().Where(x=> x.IsPublic).ToList();
            
            foreach (var fieldInfo in publicFields)
            {
                if (!fieldInfo.FieldType.IsInterface) continue;
                
                var implementor = implementors.Where(x => fieldInfo.FieldType.IsInstanceOfType(x)).ToList();
                if (implementor.Count == 0)
                    throw new Exception($"Не найден ни один InterfaceImplementor для {fieldInfo.FieldType.Name}");
                if (implementor.Count > 1)
                    throw new Exception($"InterfaceImplementor'ов для {fieldInfo.FieldType.Name} найдено более одного");
                
                fieldInfo.SetValue( component, implementor[0]);
            }

            entity.Get<T>() = (T) component;
        }

        protected abstract List<Type> GetComponents();
    }
    public abstract class EntityDescriptor<T> : EntityDescriptor
        where T : struct
    {
        protected override List<Type> GetComponents()
        {
            return new List<Type>() { typeof(T) };
        }

        public override void PrepareEntity(ref EcsEntity entity)
        {
            entity.Get<T>();
        }

        public override void PrepareEntity(ref EcsEntity entity, IImplementor[] implementors)
        {
            PrepareEntity(ref entity);
            PrepareImplementor<T>(ref entity, implementors);
        }
    }
    public abstract class EntityDescriptor<T1, T2> : EntityDescriptor
        where T1 : struct 
        where T2 : struct
    {
        protected override List<Type> GetComponents()
        {
            return new List<Type>() { typeof(T1), typeof(T2) };
        }

        public override void PrepareEntity(ref EcsEntity entity)
        {
            entity.Get<T1>();
            entity.Get<T2>();
        }
        
        public override void PrepareEntity(ref EcsEntity entity, IImplementor[] implementors)
        {
            PrepareEntity(ref entity);
            PrepareImplementor<T1>(ref entity, implementors);
            PrepareImplementor<T2>(ref entity, implementors);
        }
    }
    
    public abstract class EntityDescriptor<T1, T2, T3> : EntityDescriptor
        where T1 : struct 
        where T2 : struct
        where T3 : struct
    {
        protected override List<Type> GetComponents()
        {
            return new List<Type>() { typeof(T1), typeof(T2), typeof(T3) };
        }

        public override void PrepareEntity(ref EcsEntity entity)
        {
            entity.Get<T1>();
            entity.Get<T2>();
            entity.Get<T3>();
        }
        
        public override void PrepareEntity(ref EcsEntity entity, IImplementor[] implementors)
        {
            PrepareEntity(ref entity);
            PrepareImplementor<T1>(ref entity, implementors);
            PrepareImplementor<T2>(ref entity, implementors);
            PrepareImplementor<T3>(ref entity, implementors);
        }
    }
    
    public abstract class EntityDescriptor<T1, T2, T3, T4> : EntityDescriptor
        where T1 : struct 
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        protected override List<Type> GetComponents()
        {
            return new List<Type>() { typeof(T1), typeof(T2), typeof(T3), typeof(T4) };
        }

        public override void PrepareEntity(ref EcsEntity entity)
        {
            entity.Get<T1>();
            entity.Get<T2>();
            entity.Get<T3>();
            entity.Get<T4>();
        }
        
        public override void PrepareEntity(ref EcsEntity entity, IImplementor[] implementors)
        {
            PrepareEntity(ref entity);
            PrepareImplementor<T1>(ref entity, implementors);
            PrepareImplementor<T2>(ref entity, implementors);
            PrepareImplementor<T3>(ref entity, implementors);
            PrepareImplementor<T4>(ref entity, implementors);
        }
    }
}