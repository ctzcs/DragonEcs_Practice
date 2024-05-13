using Base;
using DCFApixels.DragonECS;


namespace GameOne.Ecs
{
    public class MapModule:IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new InitMapSystem(),EcsConsts.BEGIN_LAYER);
            b.AutoDel<CreateMapEvent>();
        }
    }
}