using DCFApixels.DragonECS;
using Survivor.Property;

namespace Survivor.Physics
{
    public class BoxColliderSystem:IEcsFixedRunProcess
    {
        
        class Box:EcsAspect
        {
            public EcsPool<BoxCollider> BoxColliders = Inc;
            public EcsPool<VelPos> VelPos = Inc;
        }
        
        public void FixedRun()
        {
            
        }
    }
}