using DCFApixels.DragonECS;

namespace GameOne.Ecs.Z_UnitTest
{
    public class UnitTestModule:IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new UnitTest1(), EcsConsts.PRE_BEGIN_LAYER)
                .Add(new UnitTest3_AddBuff())
                .AddModule(new UnitTest2Module());

        }
    }
}