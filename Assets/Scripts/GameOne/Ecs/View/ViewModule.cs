using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    class ViewModule : IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new UpdateViewSystem(), EcsConsts.END_LAYER);
            
        }
    }
}