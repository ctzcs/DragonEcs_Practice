using Base;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public class ChangeTurnSystem : IEcsFixedRunProcess
    {
        [EcsInject] EcsDefaultWorld _world;
        [EcsInject]private EcsEventWorld _eWorld;
        [EcsInject] private GameStateService _gameState;

        class Aspect:EcsAspect
        {
            public EcsPool<ChangeTurnEvent> changeTurnEventPool = Inc;
        }
        public void FixedRun()
        {
            foreach (var changeTurnEvent in _eWorld.Where(out Aspect aspect))
            {
                var toTurn = changeTurnEvent.Read(aspect.changeTurnEventPool).toTurn;
                _gameState.turn = toTurn;
                switch (toTurn)
                {
                    case ETurn.RoundStart:
                        RoundStart();
                        break;
                    case ETurn.RoundEnd:
                        RoundEnd();
                        break;
                }
            }
        }
        
        void RoundStart()
        {
            var e= _eWorld.NewEntityLong();
            e.TryGetOrAdd<ChangeTurnEvent>().toTurn = ETurn.RoundStart;
        }
        
        void RoundEnd()
        {
            var e= _eWorld.NewEntityLong();
            e.TryGetOrAdd<ChangeTurnEvent>().toTurn = ETurn.RoundEnd;
        }
    }
}