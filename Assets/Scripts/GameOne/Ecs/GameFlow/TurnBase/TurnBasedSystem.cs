using Base;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public class TurnBasedSystem : IEcsInit,IEcsFixedRunProcess
    {
        [EcsInject] EcsDefaultWorld _world;
        
        public void Init()
        {
            NewGame();
        }
        
        public void FixedRun()
        {
            
        }
        
        void NewGame()
        {
            entlong gameEntl =  _world.NewEntityLong();
            gameEntl.TryGetOrAdd<GameState>().turn = ETurn.PlayerAction;
            
        }
    }
}