using DCFApixels.DragonECS;

namespace GameOne.Ecs.UnitTest
{
    public class UnitTestModule:IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new UnitTest1(), EcsConsts.PRE_BEGIN_LAYER)
                .Add(new UnitAddBuffTest());

        }
    }
}