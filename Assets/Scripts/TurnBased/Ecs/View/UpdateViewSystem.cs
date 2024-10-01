
using Base;
using DCFApixels.DragonECS;
using Survivor.Property;
using Unity.XR.OpenVR;
using UnityEngine;

namespace GameOne.Ecs
{
    /// <summary>
    /// 更新视图的位置
    /// </summary>
    public class UpdateViewSystem : IEcsFixedRunProcess,IEcsRun
    {
        [EcsInject] EcsDefaultWorld _world;
        [EcsInject] TimeService _timeService;
        class Aspect:EcsAspect
        {
            public EcsPool<View> View = Inc;
            public EcsPool<VelPos> velPos = Inc;
        }
        
        public void FixedRun()
        {
            foreach (var ent in _world.Where(out Aspect pool))
            {
                ref readonly var velPos = ref ent.Read(pool.velPos);
                ref var view = ref ent.Get(pool.View);
                UnityEngine.Transform transform = view.transform;
                view.prePos = transform.position;
                view.nextPos = velPos.position;
                view.preScaleRate = transform.localScale.x;
                view.nextScaleRate = velPos.scaleRate;
            }
        }
        
        public void Run()
        {
            foreach (var entity in _world.Where(out Aspect pool))
            {
                /*EcsSpan a = _world.Where(out pool);*/
                // EcsReadonlyGroup g = a.WhereToGroup(out Aspect pool1);
                // EcsReadonlyGroup g1 = a.WhereToGroup(out Aspect pool2);
                // g.Clone().UnionWith(g1.Clone());
                
                ref readonly var logicTransform = ref entity.Read(pool.velPos);
                ref var view = ref entity.Get(pool.View);
                
                
                //换新目标
                /*if (logicTransform.position != view.targetPos)
                { 
                    view.startPos = view.transform.position;
                    view.targetPos = logicTransform.position;
                    view.elapsedTime = 0;
                }*/
                
                //插值
                float interpolationRatio = _timeService.time - _timeService.fixedTime / _timeService.fixedDeltaTime;
                view.transform.position = Vector3.Lerp(view.prePos,view.nextPos, interpolationRatio);
                view.transform.localScale = Vector3.Lerp(view.preScaleRate * Vector3.one, 
                    view.nextScaleRate * Vector3.one, interpolationRatio);
                view.sp.color = view.Color;
                /*if (interpolationRatio >= 1)
                {
                    view.elapsedTime = 0;
                    view.transform.position = view.targetPos;
                }
                else
                {
                    view.transform.position = Vector3.Lerp(view.startPos,view.targetPos, interpolationRatio);
                }*/


            }
            
        }

        
    }
}