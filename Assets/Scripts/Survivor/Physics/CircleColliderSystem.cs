using DCFApixels.DragonECS;
using Survivor.Property;

namespace Survivor.Physics
{
    public class CircleColliderSystem:IEcsFixedRunProcess
    {
        class Circle:EcsAspect
        {
            public EcsPool<CircleCollider> BoxColliders = Inc;
            public EcsPool<VelPos> VelPos = Inc;
        }
        
        public void FixedRun()
        {
            
        }
    }
}