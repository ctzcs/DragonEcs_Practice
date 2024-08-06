using System.Collections.Generic;
using DCFApixels.DragonECS;
using UnityEngine;

namespace GameOne.Ecs
{
    public class SpawnSystem:IEcsInit
    {
        [EcsInject]EcsDefaultWorld _world;
        private EcsPool<Health> _healthPool;
        private EcsPool<Name> _namePool;
        public void Init()
        {
            EcsDebug.Print("SpawnSystem==>Init");
            
            //将GameObject和Ecs链接
            EcsEntityConnect connect = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("GameOne/Prefab/Entity"))
                .GetComponent<EcsEntityConnect>();
            //添加组件
            var e = _world.NewEntity(Base.Template.Copy(Resources.Load<ScriptableEntityTemplate>("GameOne/Config/Hero/Revolver")));
            var elong = _world.GetEntityLong(e);
            //
            connect.ConnectWith(elong,false);
            _healthPool = _world.GetPool<Health>();
            ref var health = ref _healthPool.Add(e);
            health.healthValue = 10;
            health.minHealthValue = 0;
            health.maxHealthValue = 10;

            //添加组件
            
            var logicPool = _world.GetPool<DiffLogic>();
            ref var diffLogicComponent = ref logicPool.Add(e);
            diffLogicComponent.logic = "Hello";
            
            ref ItemContainer container = ref _world.GetPool<ItemContainer>().Add(e);
            container.itemIds = new List<entlong>();
            
            
        }
        


        
        
    }
}