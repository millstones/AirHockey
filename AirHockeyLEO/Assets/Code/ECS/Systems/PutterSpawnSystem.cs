using System.Collections;
using System.Collections.Generic;
using AirHockey.ECS.Components;
using AirHockey.ECS.UnityComponents;
using Leopotam.Ecs;
using Millstones.Common;
using Millstones.LeoECSExtension;
using Millstones.LeoECSExtension.Components;
using Millstones.LeoECSExtension.UnityComponents;
using UnityEngine;

namespace AirHockey.ECS.Systems 
{
    sealed class PutterSpawnSystem : IEcsRunSystem 
    {
        private readonly GameObjectFactory _gameObjectFactory;
        readonly EcsWorld _world = null;
        private IEnumerator _loader;
        
        private EcsFilter<OnStartNewTimeEvent, PutterTag> _onStartNewTimeFilter;

        private EcsEntity _upPutter;
        private EcsEntity _downPutter;
        private Vector3 _upPutterStartPosition;
        private Vector3 _downPutterStartPosition;

        public PutterSpawnSystem(Vector3 upPutterStartPosition, Vector3 downPutterStartPosition)
        {
            _upPutterStartPosition = upPutterStartPosition;
            _downPutterStartPosition = downPutterStartPosition;
            _loader = Loader();

        }
        
        public void Run()
        {
            _loader.MoveNext();

            if (_onStartNewTimeFilter.GetEntitiesCount() > 0)
            {
                _upPutter.Del<OnTableTag>();
                _upPutter.Get<FreezeAxisViewComponent>().FreezeAxisView.FreezeYPosition = false;
                _upPutter.Get<MoveViewComponent>().PositionView.Position = _upPutterStartPosition;
                _upPutter.Get<MoveViewComponent>().VelocityView.Velocity = Vector3.zero;
                
                _downPutter.Del<OnTableTag>();
                _downPutter.Get<FreezeAxisViewComponent>().FreezeAxisView.FreezeYPosition = false;
                _downPutter.Get<MoveViewComponent>().PositionView.Position = _downPutterStartPosition;
                _downPutter.Get<MoveViewComponent>().VelocityView.Velocity = Vector3.zero;
            }
        }
        
        IEnumerator Loader()
        {
            var loader = CreteEntity<EnemyTag>(_upPutterStartPosition);
            while (loader.MoveNext()) yield return null;
            _upPutter = loader.Current;
            
            loader = CreteEntity<PlayerTag>(_downPutterStartPosition);
            while (loader.MoveNext()) yield return null;
            _downPutter = loader.Current;
        }

        IEnumerator<EcsEntity> CreteEntity<T>(Vector3 position) where T : struct
        {
            var loader = _gameObjectFactory.Build("Putter");
            while (loader.MoveNext()) yield return EcsEntity.Null;
            var gameObject = loader.Current;

            if (gameObject == null) yield break;
            
            gameObject.AddComponent<MoveImplementor>().transform.position = position;
            gameObject.AddComponent<FreezeAxisImplementor>();
            gameObject.AddComponent<EntityReferenceImplementor>();    

            var entity = _world.NewEntity<PutterEntityDescriptor>(gameObject);
            entity.Get<T>();

            gameObject.SetActive(true);
            yield return entity;
        }
    }
}