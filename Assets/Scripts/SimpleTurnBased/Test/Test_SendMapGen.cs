using DCFApixels.DragonECS;
using Share.Input;
using SimpleTurnBased.Logic.Map;

namespace SimpleTurnBased.Test
{
    public class Test_SendMapGen:IEcsRun
    {
        [DI] private EcsDefaultWorld _world;
        [DI] private EcsEventWorld _eventWorld;

        public void Run()
        {
            ref var data = ref _world.Get<InputData>();
            if (data.WasReleaseThisFrame(EKeyCode.A))
            {
                MapExt.EmitGenMap(_eventWorld,"1");
            }
        }
    }
}