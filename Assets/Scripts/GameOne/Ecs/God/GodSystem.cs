using DCFApixels.DragonECS;
using GameOne.Ecs.Input;
using GameOne.Service;
using UnityEngine;

namespace GameOne.Ecs
{
    public class GodSystem:IEcsInit,IEcsFixedRunProcess
    {
        [EcsInject]EcsDefaultWorld _world;
        [EcsInject]EcsEventWorld _eventWorld;
        [EcsInject] private GameService service;
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
            ref WorldInput worldInput = ref _world.Get<WorldInput>();
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