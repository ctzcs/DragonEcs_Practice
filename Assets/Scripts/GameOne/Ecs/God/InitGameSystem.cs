using DCFApixels.DragonECS;

namespace GameOne
{
    public class InitGameSystem:IEcsInit
    {
        [EcsInject] private EcsDefaultWorld _world;
        [EcsInject] private GameStateService _state;
        public void Init()
        {
            _state.state = EGameState.Init;
        }
    }
}