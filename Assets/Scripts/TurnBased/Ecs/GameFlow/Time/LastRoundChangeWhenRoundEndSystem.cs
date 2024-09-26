
using Base;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public class LastRoundChangeWhenRoundEndSystem : IEcsFixedRunProcess
    {
        [EcsInject] EcsDefaultWorld _world;
        [EcsInject]private EcsEventWorld _eWorld;

        class Aspect:EcsAspect
        {
            public EcsPool<RoundEndEvent> roundEndPool = Inc;
        }

        class LastRoundAspect : EcsAspect
        {
            public EcsPool<LastRound> lastRoundPool = Inc;
        }

        public void FixedRun()
        {
            foreach (var roundEndEvent in _eWorld.Where(out Aspect aspect))
            {
                foreach (var lastRoundEnt in _world.Where(out LastRoundAspect lastRoundAspect))
                {
                    ref LastRound lastRound = ref lastRoundEnt.Get(lastRoundAspect.lastRoundPool);
                    if (lastRound.round > 0)
                    {
                        lastRound.round -= 1;
                    }
                }
            }            
        }
    }
}