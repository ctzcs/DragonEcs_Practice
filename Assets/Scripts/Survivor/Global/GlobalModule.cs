using DCFApixels.DragonECS;

namespace Survivor.Global
{
    public class GlobalModule:IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new InitGameSystem());
        }
    }
}