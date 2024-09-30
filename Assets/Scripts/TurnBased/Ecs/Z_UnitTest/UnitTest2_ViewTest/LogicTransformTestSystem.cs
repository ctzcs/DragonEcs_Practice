using Base;
using DCFApixels.DragonECS;
using UnityEngine;

namespace GameOne.Ecs.Z_UnitTest
{
    public class LogicTransformTestSystem : IEcsFixedRunProcess
    {
        [EcsInject] EcsDefaultWorld _world;
#if UNITY_EDITOR
        private static readonly EcsProfilerMarker marker = new EcsProfilerMarker("SomeMarker");
#endif
        
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