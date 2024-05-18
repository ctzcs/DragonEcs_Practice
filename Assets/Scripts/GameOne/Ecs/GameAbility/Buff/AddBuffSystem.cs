using Base;
using DCFApixels.DragonECS;
using GameOne.DesignScript.Buff;

namespace GameOne.Ecs
{
    /// <summary>
    /// 添加buff系统
    /// </summary>
    public class AddBuffSystem : IEcsFixedRunProcess
    {
        [EcsInject] EcsDefaultWorld _world;
        [EcsInject] private EcsEventWorld _eWorld;

        class Aspect:EcsAspect
        {
            public EcsPool<AddBuffEvent> addBuffEventPool = Inc;
        }

        class CarryBuffAspect:EcsAspect
        {
            public EcsPool<CarryBuffs> carryBuffsPool = Inc;
        }
        public void FixedRun()
        {
            var belongEntityPool = _world.GetPool<BelongEntity>();
            var refreshPropertyEventPool = _eWorld.GetPool<RefreshBuffPropertyEvent>();
            var buffOnAddPool = _world.GetPool<BuffOnAdd>();
            _world.Where(out CarryBuffAspect carryBuffAspect);
            foreach (var entity in _eWorld.Where(out Aspect aspect))
            {
                ref readonly var addBuffEvent = ref entity.Read(aspect.addBuffEventPool);
                int targetEntity = addBuffEvent.toEntl.ID;
                
                //buff属于谁
                ref var belongEntl = ref addBuffEvent.buffEntl.TryGetOrAdd(belongEntityPool);
                //挂载到实体上
                ref CarryBuffs carryBuffs = ref targetEntity.Get(carryBuffAspect.carryBuffsPool);
                
                AddBuffTo(ref belongEntl,addBuffEvent.toEntl,ref carryBuffs,addBuffEvent.buffEntl,buffOnAddPool);

                //刷新buff
                RefreshBuffProperty(addBuffEvent.toEntl,addBuffEvent.buffEntl,refreshPropertyEventPool);
                
                _eWorld.DelEntity(entity);
            }
        }

        /// <summary>
        /// 给对象添加Buff
        /// </summary>
        /// <param name="belongEntity"></param>
        /// <param name="to"></param>
        /// <param name="carryBuffs"></param>
        /// <param name="buff"></param>
        /// <param name="buffOnAddPool"></param>
        void AddBuffTo(ref BelongEntity belongEntity,entlong to,ref CarryBuffs carryBuffs,entlong buff,EcsPool<BuffOnAdd> buffOnAddPool)
        {
            //buff本身链接
            belongEntity.belongEntl = to;
            //持有者添加
            carryBuffs.AddBuff(buff);
            if (buff.Has(buffOnAddPool))
            {
               ref readonly var buffOnAdd = ref buff.Read(buffOnAddPool); //.Read(buff.ID);
               if (BuffDesign.OnAddFunc.TryGetValue(buffOnAdd.funcName,out var func))
               {
                   func?.Invoke();
               }
            }
            
        }

        /// <summary>
        /// 发出更新对象的属性事件
        /// </summary>
        /// <param name="to"></param>
        /// <param name="buff"></param>
        /// <param name="refreshBuffPropertyEventPool"></param>
        void RefreshBuffProperty(entlong to,entlong buff,EcsPool<RefreshBuffPropertyEvent> refreshBuffPropertyEventPool)
        {
            var refreshBuffPropertyEventEntity = _eWorld.NewEntity();
            ref var refreshBuffPropertyEvent = ref refreshBuffPropertyEventEntity.TryGetOrAdd(refreshBuffPropertyEventPool);
            refreshBuffPropertyEvent.Set(RefreshBuffPropertyEvent.EChangeType.Add,to,buff);
        }
    }
}