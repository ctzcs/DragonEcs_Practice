using Base;
using DCFApixels.DragonECS;
using GameOne.General;

namespace GameOne.Ecs
{
    /// <summary>
    /// 刷新被buff系统影响的属性的值
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    /// <typeparam name="TBuffMod"></typeparam>
    public class RefreshPropertyInfluenceByBuffSystem<TProperty,TBuffMod> : IEcsFixedRunProcess 
        where TProperty:struct,IEcsComponent,IAddable<TBuffMod>,ISubtract<TBuffMod>
        where TBuffMod:struct,IEcsComponent
    {
        [EcsInject] EcsDefaultWorld _world;
        [EcsInject] private EcsEventWorld _eWorld;
        
        class Aspect:EcsAspect
        {
            public EcsPool<RefreshBuffPropertyEvent> refreshBuffPropertyEventPool = Inc;
        }
        class BuffCarrierAspect:EcsAspect
        {
            public EcsPool<CarryBuffs> carryBuffsPool = Inc;
            public EcsPool<TProperty> propertyPool = Inc;
        }
        public void FixedRun()
        {
            
            var buffModPool = _world.GetPool<TBuffMod>();
            _world.Where(out BuffCarrierAspect carrierAspect);
            foreach (var ent in _eWorld.Where(out Aspect aspect))
            {
                ref readonly RefreshBuffPropertyEvent refreshBuffPropertyEvent = ref ent.Read(aspect.refreshBuffPropertyEventPool);
                
                entlong carrierEntl = refreshBuffPropertyEvent.needRefreshEntl;
                entlong changedBuffEntl = refreshBuffPropertyEvent.changedBuffEntl;
                
                //获取buff上的Mod属性
                ref TProperty property = ref carrierEntl.Get(carrierAspect.propertyPool);

                switch (refreshBuffPropertyEvent.changeType)
                {
                    case RefreshBuffPropertyEvent.EChangeType.Add:
                        if (changedBuffEntl.Has(buffModPool))
                        {
                            ref readonly TBuffMod mod = ref changedBuffEntl.Read(buffModPool); //buffModPool.Read(buffEnt);
                            property.Add(mod);
                        }
                        break;
                    case RefreshBuffPropertyEvent.EChangeType.Remove:
                        if (changedBuffEntl.Has(buffModPool))
                        {
                            ref readonly TBuffMod mod = ref changedBuffEntl.Read(buffModPool); //buffModPool.Read(buffEnt);
                            property.Subtract(mod);
                            //删除buff
                            _world.DelEntity(changedBuffEntl);
                        }
                        break;
                }
                
            }

            


        }
    }
}