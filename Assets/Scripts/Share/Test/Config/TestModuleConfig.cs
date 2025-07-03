using System.Collections.Generic;
using DCFApixels.DragonECS;
using UnityEngine;

namespace Share.Test.Config
{
    [CreateAssetMenu(fileName = "TestModuleConfig",menuName = "Share/Test")]
    public class TestModuleConfig:ScriptableObject
    {
        [SerializeReference]
        public List<IEcsRun> systems;
    }
}