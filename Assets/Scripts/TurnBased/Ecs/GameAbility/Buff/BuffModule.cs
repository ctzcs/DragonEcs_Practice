using Base;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public class BuffModule:IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new RemoveBuffSystem(),EcsConsts.BASIC_LAYER)
                .Add(new AddBuffSystem(), EcsConsts.BASIC_LAYER)
                //.AutoDel<AddBuffEvent>()
                .AutoDel<RefreshBuffPropertyEvent>();
        }
    }
}