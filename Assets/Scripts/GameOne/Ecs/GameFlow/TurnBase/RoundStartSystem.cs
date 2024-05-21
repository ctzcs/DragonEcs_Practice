using DCFApixels.DragonECS;
using GameOne.Ecs.Process;

namespace GameOne.Ecs
{
    public class RoundStartSystem : ITurnBasedProcess
    {
        [EcsInject] EcsDefaultWorld _world;
        [EcsInject] private GameStateService _gameState;
        
        public void RunTurn()
        {
            if (_gameState.turn == ETurn.RoundStart)
            {
                EcsDebug.Print("回合开始");
            }
            
        }
    }

    
}