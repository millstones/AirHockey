using AirHockey.Unity;
using Leopotam.Ecs;
using Millstones.Common;
using Millstones.LeoECSExtension.Components;
using UnityEngine;

namespace AirHockey.ECS.Systems
{
    public class PutterEnemyOnTableMoveSystem : IEcsRunSystem
    {
        private readonly int _speedMultiplier;
        private readonly Vector3 _targetGate;

        private EcsFilter<EnemyTag, OnTableTag, MoveViewComponent> _enemyFilter;
        private EcsFilter<PuckTag, OnTableTag, MoveViewComponent> _puckFilter;


        private EcsWorld _ecsWorld;

        private ITableService _tableService;

        public PutterEnemyOnTableMoveSystem(Vector3 targetGate, int putterMaxSpeed)
        {
            _targetGate = targetGate;
            _speedMultiplier = putterMaxSpeed;
        }

        public void Run()
        {
            foreach (var i in _enemyFilter)
            {
                ref var enemyMoveComponent = ref _enemyFilter.Get3(i);
                ref var puckMoveComponent = ref _puckFilter.Get3(i);
                    
                enemyMoveComponent.VelocityView.Velocity = 
                    _speedMultiplier * 
                    (GetTargetPoint(_targetGate, puckMoveComponent.PositionView.Position) - 
                     enemyMoveComponent.PositionView.Position).normalized;
            }
            
        }

        private Vector3 GetTargetPoint(Vector3 gate, Vector3 puck)
        {
            return new Ray(gate, puck-gate).GetPoint(Vector3.Distance(gate, puck)+0.2f);
        }


    }
}