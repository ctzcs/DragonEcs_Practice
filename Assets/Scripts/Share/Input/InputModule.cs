using DCFApixels.DragonECS;

namespace Share.Input
{
    public class InputModule:IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new InputSystem());
        }
    }
}