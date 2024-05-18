using DCFApixels.DragonECS;
using GameOne.Ecs.Input;
using UnityEngine;

namespace GameOne.Ecs.UnitTest
{
    /// <summary>
    /// 用空格创建地图
    /// </summary>
    public class UnitTest1:IEcsRun
    {
        [EcsInject] private EcsDefaultWorld _world;
        [EcsInject]private EcsEventWorld _eWorld;

        class Aspect:EcsAspect
        {
            public EcsPool<KeyPressedEvent> keyPressedEvents = Inc;
        }
        public void Run()
        {
            foreach (var id in _eWorld.Where(out Aspect aspect))
            {
                ref var keyPressEvent = ref aspect.keyPressedEvents.Get(id);
                if (keyPressEvent.key == KeyCode.Space)
                {
                    var entity = _eWorld.NewEntity();
                    ref var createMapEvent = ref _eWorld.GetPool<CreateMapEvent>().Add(entity);
                    createMapEvent.Set(10,10);
                }
            }
        }
    }
}