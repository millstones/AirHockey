using System.Collections;
using AirHockey.ECS.Components;
using AirHockey.ECS.UnityComponents;
using AirHockey.Unity;
using Leopotam.Ecs;
using Millstones.Common;
using Millstones.LeoECSExtension;
using Millstones.LeoECSExtension.Components;
using Millstones.LeoECSExtension.UnityComponents;
using UnityEngine;

namespace AirHockey.ECS.Systems
{
    public class PuckSpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly GameObjectFactory _gameObjectFactory;
        readonly EcsWorld _world = null;
        private IEnumerator _loader;

        private EcsFilter<OnStartNewTimeEvent, PuckTag> _onStartNewTimeFilter;

        private Vector3 _startPosition;
        private EcsEntity _puckEntity;
        
        public void Init()
        {
            _loader = Loader();
        }
        
        public void Run()
        {
            _loader.MoveNext();
            
            if (_onStartNewTimeFilter.GetEntitiesCount() > 0)
            {
                _puckEntity.Del<OnTableTag>();
                _puckEntity.Get<FreezeAxisViewComponent>().FreezeAxisView.FreezeYPosition = false;
                _puckEntity.Get<MoveViewComponent>().PositionView.Position = _startPosition;
                _puckEntity.Get<MoveViewComponent>().VelocityView.Velocity = Vector3.zero;
            }
        }
        
        IEnumerator Loader()
        {
            var table =Service<ITableService>.Get();
            _startPosition = table.TablePositions.CenterPoint.position;
            var loader = _gameObjectFactory.Build("Puck");
            while (loader.MoveNext()) yield return null;
            var gameObject = loader.Current;

            if (gameObject == null) yield break;
            gameObject.transform.position = _startPosition;
            
            gameObject.AddComponent<MoveImplementor>();
            gameObject.AddComponent<FreezeAxisImplementor>();

            _puckEntity = _world.NewEntity<PuckEntityDescriptor>(gameObject);
            _puckEntity.Get<ScoreComponent>();
            
            gameObject.SetActive(true);
        }
    }
}