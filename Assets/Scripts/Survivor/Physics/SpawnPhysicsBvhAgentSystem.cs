using Base;
using DCFApixels.DragonECS;
using Service;
using Survivor.Property;
using Survivor.Service;
using Unity.Mathematics;
using UnityEngine;

namespace Survivor.Physics
{
    /// <summary>
    /// 给挂了Collider的物体挂上Bvh组件
    /// </summary>
    public class SpawnPhysicsBvhAgentSystem:IEcsFixedRunProcess
    {
        [EcsInject]
        private EcsDefaultWorld _world;
        [EcsInject]
        private ServiceHub _hub;
        class BoxColliderAspect:EcsAspect
        {
            public EcsPool<BoxCollider> box = Inc;
            public EcsPool<VelPos> velPos = Inc;
            public EcsPool<PhysicsBvhAgent> bvhAgent = Exc;
        }
        
        class CircleColliderAspect:EcsAspect
        {
            public EcsPool<CircleCollider> circle = Inc;
            public EcsPool<VelPos> velPos = Inc;
            public EcsPool<PhysicsBvhAgent> bvhAgent = Exc;
        }
        
        public void FixedRun()
        {
            foreach (var ent in _world.Where(out BoxColliderAspect boxAsp))
            {
                ref readonly var box = ref ent.Read(boxAsp.box);
                ref readonly var velPos = ref ent.Read(boxAsp.velPos);
                Vector2 startPos = new Vector2(velPos.position.x - box.width / 2, velPos.position.y - box.height / 2);
                
                BvhAgent agent = new BvhAgent()
                {
                    Bounds = new Rect(startPos,new Vector2(box.width,box.height)),
                    Position = new float2(velPos.position.x,velPos.position.y) ,
                };
                AddPhysicsBvhAgent(ent,boxAsp.bvhAgent,agent);
            }
            
            foreach (var ent in _world.Where(out CircleColliderAspect circleAsp))
            {
                ref readonly var circle = ref ent.Read(circleAsp.circle);
                ref readonly var velPos = ref ent.Read(circleAsp.velPos);
                Vector2 startPos = new Vector2(velPos.position.x - circle.radius, velPos.position.y - circle.radius);
                BvhAgent agent = new BvhAgent()
                {
                    Bounds = new Rect(startPos,new Vector2(circle.radius,circle.radius)),
                    Position = new float2(velPos.position.x,velPos.position.y) ,
                };
                AddPhysicsBvhAgent(ent,circleAsp.bvhAgent,agent);
            }
        }


        void AddPhysicsBvhAgent(int ent, EcsPool<PhysicsBvhAgent> pool, BvhAgent agent)
        {
            //添加组件
            PhysicsBvhAgent bvhAgent = new PhysicsBvhAgent()
            {
                bounds = agent.Bounds,
                agent = agent,
            };
            
            ent.Add(pool, ref bvhAgent);
            
            //TODO 添加到物理世界中
            _hub.PhysicsWorld.Add(ent,agent);
        }
    }
}