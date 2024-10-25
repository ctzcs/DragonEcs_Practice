using Base;
using DCFApixels.DragonECS;
using Survivor.Physics;

namespace GameOne.Ecs
{
    class GameModule : IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new ChangeTurnSystem())
                .Add(new LastRoundChangeWhenRoundEndSystem())
                .AutoDel<RoundEndEvent>()
                .AutoDel<RoundStartEvent>()
                .AutoDel<ChangeTurnEvent>()
                .AddModule(new GodModule())
                .AddModule(new SceneModule())
                .AddModule(new GameAbilityModule());

        }
    }
}