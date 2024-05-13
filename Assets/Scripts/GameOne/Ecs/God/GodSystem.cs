using DCFApixels.DragonECS;
using GameOne.Ecs.Input;
using UnityEngine;

namespace GameOne.Ecs
{
    public class GodSystem:IEcsInit,IEcsFixedRunProcess
    {
        [EcsInject]EcsDefaultWorld _world;
        [EcsInject]EcsEventWorld _eventWorld;
        [EcsInject] private GameStateService _stateService;
        private EcsPool<Health> _healthPool;
        private EcsPool<Name> _namePool;
        private EcsPool<GameObjectConnect> _connectPool;

        class Aspect:EcsAspect
        {
            public EcsPool<KeyPressedEvent> keyPressedEventPool = Inc;
        }
        
        public void Init()
        {
            _healthPool = _world.GetPool<Health>();
            _namePool = _world.GetPool<Name>();
            _connectPool = _world.GetPool<GameObjectConnect>();
        }
        
        public void FixedRun()
        {
            Debug.Log("GodSystem==>Update");

            ref WorldInput worldInput = ref _world.Get<WorldInput>();
            
            /*foreach (var id in _world.Where(out PeopleAspect people))
            {
                if (_input.WasPressedThisFrame(KeyCode.A))
                {
                    entlong who = _world.GetEntityLong(id);
                    string name = people.namePool.Get(id).name;

                    int entity = _eventWorld.NewEntity();
                    ref DeathEvent deathEvent = ref _eventWorld.GetPool<DeathEvent>().Add(entity);
                    deathEvent.name = name;
                    deathEvent.who = who;
                }
            }
            if (_input.WasPressedThisFrame(KeyCode.B))
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

            if (_input.WasPressedThisFrame(KeyCode.S))
            {
                _stateService.state = EGameState.Saving;
            }*/


            foreach (var pressId in _eventWorld.Where(out Aspect pressEventPool))
            {
                ref var keyPressEvent = ref pressEventPool.keyPressedEventPool.Get(pressId);
                if (keyPressEvent.key == KeyCode.E)
                {
                    EcsDebug.Print("按下E");
                
                    var item = _world.NewEntity();
                    ref Item itemComponent = ref _world.GetPool<Item>().Add(item);
                    itemComponent.itemName = "道具";
                
                    var e = _eventWorld.NewEntity();
                
                    ref ChangeItemEvent itemEvent = ref _eventWorld.GetPool<ChangeItemEvent>().Add(e);

                    foreach (var id in _world.Where(out PlayerAspect playerAspect))
                    {
                        itemEvent.who = _world.GetEntityLong(id);
                        itemEvent.operation = ChangeItemEvent.EAddOrRemove.Add;
                        itemEvent.item = _world.GetEntityLong(item);
                    }
                }
            }
        }
        
    }
}