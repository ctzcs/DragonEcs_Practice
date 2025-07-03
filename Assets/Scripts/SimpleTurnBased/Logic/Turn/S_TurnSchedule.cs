using System;
using Base;
using DCFApixels.DragonECS;

namespace SimpleTurnBased.Logic.Turn
{
    public class S_TurnSchedule:IEcsInit,IEcsFixedRunProcess
    {
        [DI] private EcsDefaultWorld _world;
        class Aspect:EcsAspect
        {
            public EcsPool<C_TurnState> turnState = Inc;
        }
        public void FixedRun()
        {
            foreach (var ent in _world.Where(out Aspect aspect))
            {
                 ref var turnState = ref ent.Get(aspect.turnState);
                 turnState.ChangeTurn(turnState.nextTurn);
                 turnState.nextTurn = EWhoOperator.None;
            }
        }

        public void Init()
        {
            EcsDebug.Print($"{nameof(S_TurnSchedule)}初始化");
        }
    }
    
    
    
}