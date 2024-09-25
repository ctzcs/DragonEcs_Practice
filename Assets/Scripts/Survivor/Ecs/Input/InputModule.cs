using Base;
using DCFApixels.DragonECS;

namespace GameOne.Ecs.Input
{
    public class InputModule:IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new InputSystem(), EcsConsts.BEGIN_LAYER);
            b.AutoDel<KeyPressedEvent>();
            b.AutoDel<KeyReleaseEvent>();
                

        }
    }
}