using DCFApixels.DragonECS;
using GameOne.Ecs.Input;
using UnityEngine;

namespace GameOne.Ecs.UnitTest
{
    public class UnitTest3_AddBuff : IEcsFixedRunProcess
    {
        [EcsInject] EcsDefaultWorld _world;
        [EcsInject]private EcsEventWorld _eWorld;
        class Aspect:EcsAspect
        {
            public EcsPool<KeyPressedEvent> keyPressedEvents = Inc;
        }
        public void FixedRun()
        {
            foreach (var id in _eWorld.Where(out Aspect aspect))
            {
                ref var keyPressEvent = ref aspect.keyPressedEvents.Get(id);
                if (keyPressEvent.key == KeyCode.A)
                {
                    foreach (var player in _world.Where(out PlayerAspect playerAspect))
                    {
                        var e = _eWorld.NewEntity();
                        ref var addBuffEvent = ref _eWorld.GetPool<AddBuffEvent>().Add(e);
                        addBuffEvent.toEntl = _world.GetEntityLong(player);

                        var buff = _world.NewEntityLong( Base.Template.Copy(Resources.Load<ScriptableEntityTemplate>("GameOne/Config/Buff")));
                        addBuffEvent.buffEntl = buff;
                        addBuffEvent.fromEntl = entlong.NULL;
                        
                    } 
                }
                
            }
               
        }
    }
}