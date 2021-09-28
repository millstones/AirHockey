using AirHockey.Unity;
using Leopotam.Ecs;
using Millstones.Common;
using Millstones.LeoECSExtension.Components;
using UnityEngine;

namespace AirHockey.ECS.Systems
{
    public class MoveLimitationSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter<PutterTag, EnemyTag, MoveViewComponent> _filterEnemy;
        private EcsFilter<PutterTag, PlayerTag, MoveViewComponent> _filterPlayer;

        private Vector3 _center;
        
        public void Init()
        {
            _center = Service<ITableService>.Get().TablePositions.CenterPoint.position;
        }
        
        public void Run()
        {
            Debug.DrawLine(_center - Vector3.left, _center + Vector3.right);
            foreach (var i in _filterEnemy)
            {
                ref var enemyPos = ref _filterEnemy.Get3(i);
                if (enemyPos.PositionView.Position.z < _center.z)
                    enemyPos.PositionView.Position = new Vector3(
                        enemyPos.PositionView.Position.x,
                        enemyPos.PositionView.Position.y,
                        _center.z
                        );
            }
            
            foreach (var i in _filterPlayer)
            {
                ref var enemyPos = ref _filterPlayer.Get3(i);
                if (enemyPos.PositionView.Position.z > _center.z)
                    enemyPos.PositionView.Position = new Vector3(
                        enemyPos.PositionView.Position.x,
                        enemyPos.PositionView.Position.y,
                        _center.z
                    );
            }
        }


    }
}