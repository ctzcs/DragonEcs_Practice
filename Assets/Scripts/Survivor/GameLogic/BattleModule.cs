using DCFApixels.DragonECS;

namespace Survivor.GameLogic
{
    public class BattleModule:IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new InitBattleSystem());
        }
    }
}