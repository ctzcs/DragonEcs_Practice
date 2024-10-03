using DCFApixels.DragonECS;

namespace Survivor.Actor
{
    public struct KdAgent:IEcsComponent
    {
        public int index;
    }

    
    public struct Evt_AddToKdTree : IEcsComponent
    {
        
        public entlong target;
    }
}