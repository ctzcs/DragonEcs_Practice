using Base;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public class HealthModule:IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new HealthChangeSystem(), EcsConsts.BASIC_LAYER)
                //被buff系统影响
                .Add(new RefreshPropertyInfluenceByBuffSystem<Health, Buff_HealthMod>(), EcsConsts.END_LAYER)
                .Add(new ShowHpSystem(),EcsConsts.END_LAYER)
                .Add(new DeathSystem(), EcsConsts.POST_END_LAYER);
            b.AutoDel<DeathEvent>();
            
                
        }
    }
}