using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public class InitGameSystem:IEcsInit
    {
        [EcsInject] private EcsDefaultWorld _world;
        [EcsInject] private GameService _state;
        public void Init()
        {
            _state.State = EGameState.Init;
        }
    }
}