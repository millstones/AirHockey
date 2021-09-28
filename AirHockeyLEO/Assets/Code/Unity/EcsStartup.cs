using AirHockey.ECS.Components;
using AirHockey.ECS.Services;
using AirHockey.ECS.Systems;
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
        EcsPhysicsEventsSystem _physicsEventsSystem;

        void Start () {
            // void can be switched to IEnumerator for support coroutines.

            var tableSets = table.GetComponent<TableMonoScript>();
            var inputService = new InputService(Camera.main);
            _world = new EcsWorld ();
            _updateSystems = new EcsSystems (_world);
            _fixedUpdateSystems = new EcsSystems (_world);
            _physicsEventsSystem = new EcsPhysicsEventsSystem(_world);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_updateSystems);
#endif
            
            var gameObjectFactory = new GameObjectFactory();


            _updateSystems
                .Add(new OnStartNewTimeSystem())
                .Add(new OnTableDetectorSystem())
                .Add(new TableSpawnSystem(tableSets))
                .Add(new PutterSpawnSystem(tableSets.TablePositions.UpSpawnPoint.position, tableSets.TablePositions.DownSpawnPoint.position))
                .Add(new PuckSpawnSystem(tableSets.TablePositions.CenterPoint.position))
                .Add(new FreezeAxisSystem())
                .Add(new GoalDetectorSystem())
                
                .Add(new HUDSystem(uiGameObject))

                .Inject(gameObjectFactory)
                
                .OneFrame<OnStartNewTimeEvent>()

                .Init();
            
            
            _fixedUpdateSystems
                .Add(new PutterPlayerOnTableMoveSystem(inputService))
                .Add(new PutterEnemyOnTableMoveSystem(tableSets.TablePositions.DownGate.gameObject.transform.position, gameSettings.putterSetting.Speed))
                .Add(new MoveLimitationSystem(tableSets))

                .Init();
        }

        void Update () 
        {
            _updateSystems?.Run ();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
            _physicsEventsSystem.FixedUpdate();
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