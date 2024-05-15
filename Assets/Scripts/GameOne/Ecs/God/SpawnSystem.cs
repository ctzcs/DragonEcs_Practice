using System.Collections.Generic;
using DCFApixels.DragonECS;
using UnityEngine;

namespace GameOne.Ecs
{
    public class SpawnSystem:IEcsInit,IEcsFixedRunProcess
    {
        [EcsInject]EcsDefaultWorld _world;
        private EcsPool<Health> _healthPool;
        private EcsPool<Name> _namePool;
        public void Init()
        {
            EcsDebug.Print("SpawnSystem==>Init");
            
            //将GameObject和Ecs链接
            EcsEntityConnect connect = UnityEngine.Object.Instantiate(UnityEngine.Resources.Load<GameObject>("Entity"))
                .GetComponent<EcsEntityConnect>();
            //添加组件
            var e = _world.NewEntity();
            var elong = _world.GetEntityLong(e);
            //
            connect.ConnectWith(elong,false);
            _healthPool = _world.GetPool<Health>();
            ref var health = ref _healthPool.Add(e);
            health.healthValue = 10;
            health.minHealthValue = 0;
            health.maxHealthValue = 10;

            //添加组件
            _namePool = _world.GetPool<Name>();
            ref var nameComponent = ref _namePool.Add(e);
            nameComponent.name = "Anna";

            var logicPool = _world.GetPool<DiffLogic>();
            ref var diffLogicComponent = ref logicPool.Add(e);
            diffLogicComponent.logic = "Hello";
            
            _world.GetTagPool<PlayerTag>().Add(e);
            ref ItemContainer container = ref _world.GetPool<ItemContainer>().Add(e);
            container.itemIds = new List<entlong>();
        }
        
        public void FixedRun()
        {
            Debug.Log("SpawnSystem==>Update"); 
        }
        
    }
}