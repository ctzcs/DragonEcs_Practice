using Aspect;
using Component;
using DCFApixels.DragonECS;
using UnityEngine;

namespace System
{
    public class GodSystem:IEcsInit,IEcsRun
    {
        [EcsInject]EcsDefaultWorld _world;
        [EcsInject]EcsEventWorld _eventWorld;
        [EcsInject] private GameStateService _stateService;
        private EcsPool<Health> _healthPool;
        private EcsPool<Name> _namePool;
        private EcsPool<GameObjectConnect> _connectPool;
        public void Init()
        {
            _healthPool = _world.GetPool<Health>();
            _namePool = _world.GetPool<Name>();
            _connectPool = _world.GetPool<GameObjectConnect>();
        }
        
        public void Run()
        {
            Debug.Log("GodSystem==>Update");

            foreach (var id in _world.Where(out PeopleAspect people))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    entlong who = _world.GetEntityLong(id);
                    string name = people.namePool.Get(id).name;

                    int entity = _eventWorld.NewEntity();
                    ref DeathEvent deathEvent = ref _eventWorld.GetPool<DeathEvent>().Add(entity);
                    deathEvent.name = name;
                    deathEvent.who = who;
                }
            }
            if (Input.GetKey(KeyCode.B))
            {
                EcsEntityConnect connect = UnityEngine.Object.Instantiate(UnityEngine.Resources.Load<GameObject>("Entity"))
                    .GetComponent<EcsEntityConnect>();
                //添加组件
                var e = _world.NewEntity();
                var elong = _world.GetEntityLong(e);
                connect.ConnectWith(elong,false);
                
                _healthPool.Add(e);
                _healthPool.Get(e).health = 20;

                
                _namePool.Add(e);
                _namePool.Get(e).name = "LuRen A";
                
                var logicPool = _world.GetPool<DiffLogic>();
                ref var diffLogicComponent = ref logicPool.Add(e);
                diffLogicComponent.logic = "Fuck";
            }

            if (Input.GetKey(KeyCode.S))
            {
                _stateService.state = EGameState.Saving;
                
            }
        }

        
    }
}