using DCFApixels.DragonECS;

namespace Survivor.Global
{
    public struct Time:IEcsWorldComponent<Time>
    {
        public int tick;
        public void Init(ref Time component, EcsWorld world)
        {
            component.tick = 0;
        }

        public void OnDestroy(ref Time component, EcsWorld world)
        {
            
        }
    }
}