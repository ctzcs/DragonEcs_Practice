using DCFApixels.DragonECS;
using GameOne.Ecs.Process;

namespace GameOne.Ecs
{
    public class RoundStartSystem : ITurnBasedProcess
    {
        [EcsInject] EcsDefaultWorld _world;
        [EcsInject] private GameService game;
        
        public void RunTurn()
        {
            if (((LevelMode)game.NowMode).Turn == LevelMode.ETurn.RoundStart)
            {
                EcsDebug.Print("回合开始");
            }
            
        }
    }

    
}