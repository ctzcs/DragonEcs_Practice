using Base;
using DCFApixels.DragonECS;
using GameOne.Service;

namespace GameOne.Ecs
{
    public class ChangeTurnSystem : IEcsFixedRunProcess
    {
        [EcsInject]EcsDefaultWorld _world;
        [EcsInject]EcsEventWorld _eWorld;
        [EcsInject]GameService game;

        class Aspect:EcsAspect
        {
            public EcsPool<ChangeTurnEvent> changeTurnEventPool = Inc;
        }
        public void FixedRun()
        {
            foreach (var changeTurnEvent in _eWorld.Where(out Aspect aspect))
            {
                var toTurn = changeTurnEvent.Read(aspect.changeTurnEventPool).toTurn;
                ((LevelMode)game.NowMode).Turn = toTurn;
                switch (toTurn)
                {
                    case LevelMode.ETurn.RoundStart:
                        RoundStart();
                        break;
                    case LevelMode.ETurn.RoundEnd:
                        RoundEnd();
                        break;
                }
            }
        }

        
        
        void RoundStart()
        {
            var e= _eWorld.NewEntityLong();
            e.TryGetOrAdd<RoundStartEvent>();
        }
        
        void RoundEnd()
        {
            var e= _eWorld.NewEntityLong();
            e.TryGetOrAdd<RoundEndEvent>();
        }
    }
}