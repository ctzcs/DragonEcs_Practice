using System.Collections.Generic;
using DCFApixels.DragonECS;
using Share.Test.Config;
using UnityEngine;

namespace Share.Test
{
    public class TestModule:IEcsModule
    {
        private List<IEcsRun> _testSystem;

        public TestModule(string path)
        {
            var res = Resources.Load<TestModuleConfig>(path);
            _testSystem = res.systems;

            
        }
        
        public void Import(EcsPipeline.Builder b)
        {
            foreach (var system in _testSystem)
            {
                b.Add(system);
            }
        }
    }
}