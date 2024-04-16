using DCFApixels.DragonECS;

namespace System
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