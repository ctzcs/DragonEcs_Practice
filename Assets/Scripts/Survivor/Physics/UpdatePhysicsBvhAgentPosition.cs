using Base;
using DCFApixels.DragonECS;
using Survivor.Property;
using Unity.Mathematics;
using UnityEngine;

namespace Survivor.Physics
{
    /// <summary>
    /// 更新物体的位置
    /// </summary>
    public class UpdatePhysicsBvhAgentPosition:IEcsFixedRunProcess
    {
        [DI]
        private EcsDefaultWorld _world;
        class Aspect:EcsAspect
        {
            public EcsPool<VelPos> velPos = Inc;
            public EcsPool<PhysicsBvhAgent> bvhAgent = Inc;
            public EcsPool<CircleCollider> circle = Opt;
            public EcsPool<BoxCollider> box = Opt;
        }
        public void FixedRun()
        {
            foreach (var ent in _world.Where(out Aspect asp))
            {
                var velPos = ent.Read(asp.velPos);
                ref var bvhAgent = ref ent.Get(asp.bvhAgent);
                bvhAgent.agent.Position = new float2(velPos.position.x,velPos.position.y);
                
                if (asp.circle.Has(ent))
                {
                    var circle = ent.Read(asp.circle);
                    var newWidth = circle.radius * velPos.scaleRate;
                    var minXY = new Vector2(velPos.position.x - newWidth/2,velPos.position.y - newWidth/2);
                    bvhAgent.bounds = new Rect(minXY,new Vector2(newWidth,newWidth));
                    bvhAgent.agent.Bounds = bvhAgent.bounds;
                }
                else if (asp.box.Has(ent))
                {
                    var box = ent.Read(asp.box);
                    var newWidth = box.width * velPos.scaleRate;
                    var newHeight = box.height * velPos.scaleRate;
                    var minXY = new Vector2(velPos.position.x - newWidth/2,velPos.position.y - newHeight/2);
                    bvhAgent.bounds = new Rect(minXY,new Vector2(newWidth,newWidth));
                    bvhAgent.agent.Bounds = bvhAgent.bounds;
                }
                
                
            }
        }
    }
}