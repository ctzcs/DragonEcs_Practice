using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    class GameModule : IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new TurnBasedSystem(), EcsConsts.BEGIN_LAYER)
                .Add(new LastRoundChangeWhenRoundEndSystem(),EcsConsts.BASIC_LAYER)
                .AddModule(new GodModule())
                .AddModule(new SceneModule())
                .AddModule(new GameAbilityModule());
        }
    }
}