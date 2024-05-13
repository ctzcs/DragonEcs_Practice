

using DCFApixels.DragonECS;

namespace GameTwo
{
    public struct WorldInfo:IEcsWorldComponent<WorldInfo>
    {
        public string name;
        public void Init(ref WorldInfo info, EcsWorld world)
        {
            name = nameof(world);
        }

        public void OnDestroy(ref WorldInfo info, EcsWorld world)
        {
            
        }
    }
}