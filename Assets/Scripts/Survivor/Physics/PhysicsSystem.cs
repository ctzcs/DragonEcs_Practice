using System;
using DCFApixels.DragonECS;
using Survivor.Property;
using Survivor.Service;
using Unity.Mathematics;


namespace Survivor.Physics
{
    public class PhysicsSystem:IEcsInit,IEcsFixedRunProcess
    {
        [EcsInject] private ServiceHub _serviceHub;
        class Box:EcsAspect
        {
            public EcsPool<BoxCollider> BoxColliders = Inc;
            public EcsPool<VelPos> VelPos = Inc;
        }

        class Circle:EcsAspect
        {
            public EcsPool<CircleCollider> BoxColliders = Inc;
            public EcsPool<VelPos> VelPos = Inc;
        }
        public void Init()
        {
            _serviceHub.PhysicsWorld.Init();
        }
        public void FixedRun()
        {
            //处理box
            //处理circle
            _serviceHub.PhysicsWorld.Step(UnityEngine.Time.fixedTime);
        }

       
    }


    
}



