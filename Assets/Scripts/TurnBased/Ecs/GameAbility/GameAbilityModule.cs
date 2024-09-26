using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public class GameAbilityModule:IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.AddModule(new BuffModule())
                .AddModule(new HealthModule());
        }
    }
}