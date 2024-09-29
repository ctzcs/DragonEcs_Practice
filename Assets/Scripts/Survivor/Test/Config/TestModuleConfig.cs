using System.Collections.Generic;
using DCFApixels.DragonECS;
using UnityEngine;

namespace Survivor.Test.Config
{
    [CreateAssetMenu(fileName = "TestModuleConfig",menuName = "Survivor/Test")]
    public class TestModuleConfig:ScriptableObject
    {
        [SerializeReference]
        public List<IEcsRun> systems;
    }
}