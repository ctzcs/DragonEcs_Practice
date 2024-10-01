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
}