using System;
using Component;
using DCFApixels.DragonECS;

namespace Module
{
    public class TestModule:IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new InitGameSystem())
                .Add(new GodSystem())
                .Add(new SpawnSystem())
                .Add(new ShowHpSystem())
                .Add(new DeathSystem())
                .Add(new DeleteOneFrameComponentSystem<DeathEvent>())
                .Add(new SaveSystem());
        }
    }
}