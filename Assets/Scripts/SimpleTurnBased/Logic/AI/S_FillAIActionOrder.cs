using Base;
using DCFApixels.DragonECS;
using SimpleTurnBased.Logic.Base;
using SimpleTurnBased.Logic.Turn;

namespace SimpleTurnBased.Logic.AI
{
    /// <summary>
    /// 填充顺序
    /// </summary>
    public class S_FillAIActionOrder:IEcsFixedRunProcess
    {
        [DI]private EcsDefaultWorld _world;
        class Aspect:EcsAspect
        {
            public EcsPool<C_AIActionOrder> aiActionOrder = Inc;
        }

        class TurnAspect:EcsAspect
        {
            public EcsPool<C_TurnState> turnState = Inc;
        }
        class AIAspect:EcsAspect
        {
            public EcsPool<C_AI> ai = Inc;
            public EcsPool<C_UnitState> state = Inc;
        }
        public void FixedRun()
        {
            foreach (var ent in _world.Where(out TurnAspect turnAspect))
            {
                ref readonly var turnState = ref ent.Read(turnAspect.turnState);
                if (turnState.turn != EWhoOperator.AI)
                {
                    return;
                }
            }
            
            foreach (var ent in _world.Where(out Aspect aspect))
            {
                ref var aiActionOrder = ref ent.Get(aspect.aiActionOrder);
                aiActionOrder.entActionOrder ??= new();
                //如果没有ai需要更新了，就获取一个更新列表
                if (aiActionOrder.entActionOrder.Count <= 0 )
                {
                    foreach (var aiEnt in _world.Where(out AIAspect aiAspect))
                    {
                       ref readonly var state = ref aiEnt.Read(aiAspect.state);
                       if (state is { isAlive: true, isValid: true })
                       {
                           aiActionOrder.entActionOrder.Enqueue(aiEnt);
                       }
                    }
                }
                
            }
        }
    }
}