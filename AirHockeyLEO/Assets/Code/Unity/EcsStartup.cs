using AirHockey.ECS.Components;
using AirHockey.ECS.Services;
using AirHockey.ECS.Systems;
using LeoEcsPhysics;
using Leopotam.Ecs;
using Millstones.Common;
using Millstones.LeoECSExtension.LeoEcsPhysics;
using UnityEngine;

namespace AirHockey.Unity {
    sealed class EcsStartup : MonoBehaviour
    {
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private GameObject table;
        [SerializeField] private GameObject uiGameObject;
        
        EcsWorld _world;
        EcsSystems _updateSystems;
        EcsSystems _fixedUpdateSystems;

        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            Service<ITableService>.Set(table.GetComponent<ITableService>());
            Service<GameSettings>.Set(gameSettings);
            Service<InputService>.Set(new InputService(Camera.main));
            
            _world = new EcsWorld ();
            _updateSystems = new EcsSystems (_world);
            _fixedUpdateSystems = new EcsSystems (_world);
            EcsPhysicsEvents.ecsWorld = _world;
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_updateSystems);
#endif
            
            var gameObjectFactory = new GameObjectFactory();
            
            
            _updateSystems
                .Add(new PhysicsEventsService())
                .Add(new OnStartNewTimeSystem())
                .Add(new OnTableDetectorSystem())
                .Add(new TableSpawnSystem())
                .Add(new PutterSpawnSystem())
                .Add(new PuckSpawnSystem())
                .Add(new FreezeAxisSystem())
                .Add(new GoalDetectorSystem())
                
                .Add(new HUDSystem(uiGameObject))

                .Inject(gameObjectFactory)
                
                .OneFrame<OnStartNewTimeEvent>()
                .OneFrame<PhysicsEventsService.PhysicsEventsData>()
                .OneFrame<OnCollisionEnterEvent>()
                .OneFrame<OnTriggerEnterEvent>()
                
                .Init();
            
            
            _fixedUpdateSystems
                .Add(new PutterPlayerOnTableMoveSystem())
                .Add(new PutterEnemyOnTableMoveSystem())
                .Add(new MoveLimitationSystem())

                .Init();
        }

        void Update () 
        {
            _updateSystems?.Run ();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Run ();
        }

        void OnDestroy () {
            if (_updateSystems != null) 
            {
                _updateSystems.Destroy ();
                _updateSystems = null;
                _world.Destroy ();
                _world = null;
            }
            if (_fixedUpdateSystems != null) 
            {
                _fixedUpdateSystems.Destroy ();
                _fixedUpdateSystems = null;
            }
        }
    }
}