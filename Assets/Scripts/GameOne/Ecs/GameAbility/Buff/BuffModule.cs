using Base;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public class BuffModule:IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new AddBuffSystem(), EcsConsts.BASIC_LAYER);
            
            b.AutoDel<RefreshBuffPropertyEvent>();
        }
    }
}