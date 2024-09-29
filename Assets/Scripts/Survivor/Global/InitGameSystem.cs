using DCFApixels.DragonECS;
using Survivor.Input;
using UnityEngine;

namespace Survivor.Global
{
    public class InitGameSystem:IEcsInit
    {
        [EcsInject]private EcsDefaultWorld _world;
        public void Init()
        {
            var god = Object.Instantiate(Resources.Load<ScriptableEntityTemplate>("Survivor/God"));
            ref WorldData data = ref _world.Get<WorldData>();
            data.god = _world.NewEntityLong(god);

            
        }
    }
}