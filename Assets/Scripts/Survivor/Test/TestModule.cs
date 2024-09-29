using System.Collections.Generic;
using DCFApixels.DragonECS;
using Survivor.Test.Config;
using UnityEngine;

namespace Survivor.Test
{
    public class TestModule:IEcsModule
    {
        private List<IEcsRun> _testSystem;
        public void Import(EcsPipeline.Builder b)
        {
            _testSystem = Resources.Load<TestModuleConfig>("Survivor/TestModuleConfig").systems;
            foreach (var system in _testSystem)
            {
                b.Add(system);
            }
        }
    }
}