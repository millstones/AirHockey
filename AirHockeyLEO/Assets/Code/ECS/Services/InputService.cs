using Leopotam.Ecs;
using Millstones.LeoECSExtension;
using UnityEngine;

namespace AirHockey.ECS.Services
{
    public interface IInputService
    {
        InputService.HitInfo GetMouseHitInfo(EcsWorld ecsWorld);
        bool IsLeftMouseButtonDown { get; }
    }
    
    public class InputService : IInputService
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public float Vertical => Input.GetAxis("Vertical");
        public Vector3 ScreenMousePosition => Input.mousePosition;
        public Vector3 WorldMousePosition => _camera.ScreenToWorldPoint(ScreenMousePosition);
        public bool IsLeftMouseButtonDown => Input.GetMouseButton(0);

        private readonly Camera _camera;

        public InputService(Camera camera)
        {
            _camera = camera;
        }

        public HitInfo GetMouseHitInfo(EcsWorld ecsWorld)
        {
            var ray = _camera.ScreenPointToRay(ScreenMousePosition);

            var hitPoint = Vector3.zero;
            var hitEntity = EcsEntity.Null;
            if (Physics.Raycast(ray, out var hitInfo))
            {
                hitPoint = hitInfo.point;
                ecsWorld.TryGetEntityByGameObject(hitInfo.transform.gameObject, out hitEntity);
            }
                
            return new HitInfo(hitEntity, hitPoint);
        }
        
        
        public readonly struct HitInfo
        {
            public readonly Vector3 HitPoint;
            public readonly EcsEntity EntityIdMouseHit;

            public HitInfo(EcsEntity entityIdMouseHit, Vector3 hitPoint)
            {
                EntityIdMouseHit = entityIdMouseHit;
                HitPoint = hitPoint;
            }
        }
    }
}