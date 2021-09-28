using AirHockey.ECS.Components;
using Leopotam.Ecs;

namespace AirHockey.ECS.Systems
{
    public class FreezeAxisSystem : IEcsRunSystem
    {
        private EcsFilter<OnTableTag, FreezeAxisViewComponent> _filter;
        public void Run()
        {
            foreach (var i in _filter)
            {
                _filter.Get2(i).FreezeAxisView.FreezeYPosition = true;

            }
        }
    }
}