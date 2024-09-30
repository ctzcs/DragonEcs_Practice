using Base;
using DCFApixels.DragonECS;
using UnityEngine;

namespace GameOne.Ecs.Z_UnitTest
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

                    Vector3 offset = Random.insideUnitSphere;
                    offset.z = 0;
                    logicTransform.position += offset;
                    logicTransform.scaleRate = Random.Range(0, 1f);

                }
            
            
        }
    }
}