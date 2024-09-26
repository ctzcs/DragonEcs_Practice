using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public class GodModule:IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new InitGameSystem())
                .Add(new GodSystem())
                .Add(new SpawnSystem())
                .Add(new SaveSystem());

        }
    }
}