using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    class SceneModule : IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.AddModule(new ItemModule())
                .AddModule(new MapModule())
                .AddModule(new CharacterModule());
        }
    }
}