using System;
using DCFApixels.DragonECS;
using Survivor.Property;


namespace Survivor.Physics
{
    public class PhysicsSystem:IEcsFixedRunProcess
    {
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
        public void FixedRun()
        {
            //处理box
            //处理circle
        }
    }
    
    
    [Flags]
    public enum CollisionLayer {
        None = 0,
        Player =  1 << 0,
        Enemy = 1 << 1
    }
    
    
    //初筛
    //两两检测
    public static class Physics
    {


        public static bool CheckLayer(CollisionLayer targetLayer,CollisionLayer collisionLayer)
        {
            int mask = (int)collisionLayer & (int)targetLayer;
            return mask == (int)targetLayer;
        }
        public static void CheckCollision(CircleCollider a,CircleCollider b)
        {
        }
        
    }
}



