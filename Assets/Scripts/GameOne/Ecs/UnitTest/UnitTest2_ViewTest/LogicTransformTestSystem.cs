using Base;
using DCFApixels.DragonECS;
using UnityEngine;

namespace GameOne.Ecs.UnitTest
{
    public class LogicTransformTestSystem : IEcsFixedRunProcess
    {
        [EcsInject] EcsDefaultWorld _world;

        class Aspect:EcsAspect
        {
            public EcsPool<LogicTransform> LogicTransform = Inc;
        }
        public void FixedRun()
        {
            foreach (var entity in _world.Where(out Aspect pools))
            {
               ref var logicTransform = ref entity.Get(pools.LogicTransform);
               logicTransform.position += Random.insideUnitSphere;
               
            }
        }
    }
}