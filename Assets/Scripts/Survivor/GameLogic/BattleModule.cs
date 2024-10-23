using DCFApixels.DragonECS;
using Survivor.Physics;

namespace Survivor.GameLogic
{
    public class BattleModule:IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new InitBattleSystem())
                .Add(new PhysicsSystem());
        }
    }
}