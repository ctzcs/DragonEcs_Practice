using DCFApixels.DragonECS;

namespace GameOne.Ecs.Z_UnitTest
{
    class UnitTest2Module : IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new CatSpawnSystem(),EcsConsts.BEGIN_LAYER)
                .Add(new LogicTransformTestSystem(), EcsConsts.BASIC_LAYER);
        }
    }
}