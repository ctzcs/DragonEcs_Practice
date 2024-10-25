using DCFApixels.DragonECS;

namespace Survivor.Physics
{
    public class PhysicsModule:IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new SpawnPhysicsBvhAgentSystem())
                .Add(new UpdatePhysicsBvhAgentPosition())
                .Add(new PhysicsSystem());
        }
    }
}