
using Base;
using DCFApixels.DragonECS;
using UnityEngine;

namespace GameOne.Ecs
{
    public class UpdateViewSystem : IEcsRun
    {
        [EcsInject] EcsDefaultWorld _world;
        [EcsInject] TimeService _timeService;
        class Aspect:EcsAspect
        {
            public EcsPool<View> View = Inc;
            public EcsPool<LogicTransform> LogicTransform = Inc;
        }
        
        public void Run()
        {
            foreach (var entity in _world.Where(out Aspect pool))
            {
                ref readonly var logicTransform = ref entity.Read(pool.LogicTransform);
                ref var view = ref entity.Get(pool.View);

                view.elapsedTime += _timeService.deltaTime;
                
                if (logicTransform.position != view.targetPos)
                { 
                    view.targetPos = logicTransform.position;
                    view.elapsedTime = 0;
                }
                
                //插值
                float interpolationRatio = view.elapsedTime / _timeService.fixedDeltaTime;
                if (interpolationRatio >= 1)
                {
                    view.elapsedTime = 0;
                    view.transform.position = view.targetPos;
                }
                else
                {
                    view.transform.position = Vector3.Lerp(view.startPos,view.targetPos, interpolationRatio);
                }
                
                
            }
        }
    }
}