using Base;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    /// <summary>
    /// 移除Buff系统
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RemoveBuffSystem : IEcsFixedRunProcess
    {
        [EcsInject] EcsDefaultWorld _world;
        [EcsInject] EcsEventWorld _eWorld;
        class Aspect:EcsAspect
        {
            public EcsPool<BelongEntity> belongPool = Inc;
            public EcsPool<LastRound> lastRoundPool = Inc;
            public EcsPool<Buff> buffPool = Inc;
        }
        public void FixedRun()
        {
            var carryBuffsPool = _world.GetPool<CarryBuffs>();
            var refreshBuffPropertyEventPool = _eWorld.GetPool<RefreshBuffPropertyEvent>();
            foreach (var buffEnt in _world.Where(out Aspect buffs))
            {
                ref readonly var lastRound = ref buffEnt.Read(buffs.lastRoundPool);
                if (IsNoLastRound(lastRound))
                {
                    entlong buffEntl = _world.GetEntityLong(buffEnt);
                    RemoveBuffFromBelongEntity(buffEntl,buffs,carryBuffsPool,refreshBuffPropertyEventPool);
                }
                
            }
        }


        /// <summary>
        /// 还有剩余回合吗，没有就移除
        /// </summary>
        /// <param name="lastRound"></param>
        /// <returns></returns>
        bool IsNoLastRound(in LastRound lastRound)
        {
            return lastRound.round == 0;
        }

        /// <summary>
        /// 从属于组件中移除buff
        /// </summary>
        /// <param name="buffEntity"></param>
        /// <param name="buffs"></param>
        /// <param name="carryBuffsPool"></param>
        void RemoveBuffFromBelongEntity(entlong buffEntity,Aspect buffs,EcsPool<CarryBuffs> carryBuffsPool,EcsPool<RefreshBuffPropertyEvent> refreshBuffPropertyEventPool)
        {
            ref readonly var belongEntity = ref buffEntity.Read(buffs.belongPool);// buffs.belongPool.Read(buffEntity.ID);
            ref var carryBuffs = ref belongEntity.belongEntl.Get(carryBuffsPool);
            carryBuffs.RemoveBuff(buffEntity);
            
            RefreshBuffProperty(belongEntity.belongEntl,buffEntity,refreshBuffPropertyEventPool);
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
            refreshBuffPropertyEvent.Set(RefreshBuffPropertyEvent.EChangeType.Remove,to,buff);
        } 
    }
}