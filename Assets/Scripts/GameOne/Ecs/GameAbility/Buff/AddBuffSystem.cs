using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public class AddBuffSystem : IEcsFixedRunProcess
    {
        [EcsInject] EcsDefaultWorld _world;
        [EcsInject] private EcsEventWorld _eWorld;

        class Aspect:EcsAspect
        {
            public EcsPool<AddBuffEvent> addBuffEventPool = Inc;
        }

        class OwnBuffAspect:EcsAspect
        {
            public EcsPool<CarryBuffs> ownBuffsPool = Inc;
        }
        public void FixedRun()
        {
            var belongEntityPool = _world.GetPool<BelongEntity>();
            _world.Where(out OwnBuffAspect ownBuffAspect);
            foreach (var id in _world.Where(out Aspect aspect))
            {
                ref readonly var addBuffEvent = ref aspect.addBuffEventPool.Read(id);
                int targetId = addBuffEvent.to.ID;
                
                //buff属于谁
                ref var belongEntity = ref belongEntityPool.Add(addBuffEvent.buffEntity.ID);
                belongEntity.belong = addBuffEvent.to;
                
                //挂载到实体上
                ref CarryBuffs carryBuffs = ref ownBuffAspect.ownBuffsPool.Get(targetId);
                carryBuffs.AddBuff(addBuffEvent.buffEntity);

                //刷新buff
                var refreshBuffPropertyEventEntity = _eWorld.NewEntity();
                ref var refreshBuffPropertyEvent = ref _eWorld.GetPool<RefreshBuffPropertyEvent>().Add(refreshBuffPropertyEventEntity);
                refreshBuffPropertyEvent.Set(addBuffEvent.to,addBuffEvent.buffEntity);
            }
        }
    }
}