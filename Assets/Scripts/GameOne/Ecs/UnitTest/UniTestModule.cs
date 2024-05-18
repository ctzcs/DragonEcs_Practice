using DCFApixels.DragonECS;

namespace GameOne.Ecs.UnitTest
{
    public class UniTestModule:IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new UnitTest1(), EcsConsts.PRE_BEGIN_LAYER)
                .Add(new UnitAddBuffTest());

        }
    }
}