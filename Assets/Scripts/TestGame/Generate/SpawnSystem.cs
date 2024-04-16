using Component;
using DCFApixels.DragonECS;
using UnityEngine;

namespace System
{
    public class SpawnSystem:IEcsInit,IEcsRun
    {
        [EcsInject]EcsDefaultWorld _world;
        private EcsPool<Health> _healthPool;
        private EcsPool<Name> _namePool;
        public void Init()
        {
            EcsDebug.Print("SpawnSystem==>Init");
            
            EcsEntityConnect connect = UnityEngine.Object.Instantiate(UnityEngine.Resources.Load<GameObject>("Entity"))
                .GetComponent<EcsEntityConnect>();
            //添加组件
            var e = _world.NewEntity();
            var elong = _world.GetEntityLong(e);
            connect.ConnectWith(elong,false);
            _healthPool = _world.GetPool<Health>();
            ref var healthComponent = ref _healthPool.Add(e);
            healthComponent.health = 10;

            //添加组件
            _namePool = _world.GetPool<Name>();
            ref var nameComponent = ref _namePool.Add(e);
            nameComponent.name = "Anna";

            var logicPool = _world.GetPool<DiffLogic>();
            ref var diffLogicComponent = ref logicPool.Add(e);
            diffLogicComponent.logic = "Hello";
            
            _world.GetTagPool<PlayerTag>().Add(e);
        }
        
        public void Run()
        {
            Debug.Log("SpawnSystem==>Update"); 
        }
        
    }
}