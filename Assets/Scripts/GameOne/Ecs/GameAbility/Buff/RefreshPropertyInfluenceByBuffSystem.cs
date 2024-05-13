using System.Collections.Generic;
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
        where TProperty:struct,IEcsComponent,IAddable<TBuffMod>
        where TBuffMod:struct,IEcsComponent
    {
        [EcsInject] EcsDefaultWorld _world;
        [EcsInject] private EcsEventWorld _eWorld;

        private HashSet<entlong> _refreshedSet = new HashSet<entlong>();
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
            _refreshedSet.Clear();
            var buffModPool = _world.GetPool<TBuffMod>();
            _world.Where(out BuffCarrierAspect carrierAspect);
            foreach (var id in _eWorld.Where(out Aspect aspect))
            {
                ref readonly RefreshBuffPropertyEvent refreshBuffPropertyEvent = ref aspect.refreshBuffPropertyEventPool.Read(id);
                if (_refreshedSet.Contains(refreshBuffPropertyEvent.refreshTarget))
                {
                    //包含说明已经刷新过了
                    continue;
                }
                //刷新并加入已经刷新的列表
                _refreshedSet.Add(refreshBuffPropertyEvent.refreshTarget);
                int carrierId = refreshBuffPropertyEvent.refreshTarget.ID;
                
                ref TProperty property = ref carrierAspect.propertyPool.Get(carrierId);
                ref CarryBuffs carryBuffs = ref carrierAspect.carryBuffsPool.Get(carrierId);
                
                for (int i = 0; i < carryBuffs.buffs.Count; i++)
                {
                    int buffId = carryBuffs.buffs[i].ID;
                    if (buffModPool.Has(buffId))
                    {
                        ref readonly TBuffMod mod = ref buffModPool.Read(buffId);
                        property.Add(mod);
                    }
                }
            }

            


        }
    }
}