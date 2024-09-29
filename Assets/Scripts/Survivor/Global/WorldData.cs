using DCFApixels.DragonECS;

namespace Survivor.Global
{
    public struct WorldData:IEcsWorldComponent<WorldData>
    {
        public entlong god;
        public void Init(ref WorldData component, EcsWorld world)
        {
            component.god = entlong.NULL;
        }

        public void OnDestroy(ref WorldData component, EcsWorld world)
        {
            
        }
    }

    
}