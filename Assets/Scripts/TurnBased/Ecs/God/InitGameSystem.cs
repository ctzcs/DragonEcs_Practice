using DCFApixels.DragonECS;
using GameOne.Service;

namespace GameOne.Ecs
{
    public class InitGameSystem:IEcsInit
    {
        [DI] private EcsDefaultWorld _world;
        [DI] private GameService _state;
        public void Init()
        {
            _state.State = EGameState.Init;
        }
    }
}