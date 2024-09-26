using System.Collections.Generic;
using Base;
using DCFApixels.DragonECS;


namespace GameOne.Ecs
{
    public class ChangeItemSystem:IEcsFixedRunProcess
    {
        [EcsInject]private EcsDefaultWorld _defaultWorld;
        [EcsInject]private EcsEventWorld _eventWorld;
        class ChangeItemAspect:EcsAspect
        {
            public EcsPool<ChangeItemEvent> changeItemEventPool = Inc;
        }
        
        public void FixedRun()
        {
            EcsPool<ItemContainer> itemBagPool = _defaultWorld.GetPool<ItemContainer>();
            foreach (var id in _eventWorld.Where(out ChangeItemAspect aspect))
            {
                ChangeItemEvent changeItemEvent = aspect.changeItemEventPool.Get(id);
                entlong whoEntity = changeItemEvent.who;
                entlong itemEntity = changeItemEvent.item;
                
                if (!whoEntity.Has(itemBagPool))
                {
                    continue;
                }

                ref ItemContainer itemContainer = ref whoEntity.Get(itemBagPool);
                switch (changeItemEvent.operation)
                {
                    case ChangeItemEvent.EAddOrRemove.Add:
                        AddItem(itemContainer.itemIds,itemEntity);
                        break;
                    case ChangeItemEvent.EAddOrRemove.Remove:
                        RemoveItem(itemContainer.itemIds,itemEntity);
                        break;
                }
                
                
            }
        }


        void RemoveItem(List<entlong> list,entlong id)
        {
            if (!list.Contains(id))
            {
                return;
            }
            list.Remove(id);
        }

        void AddItem(List<entlong> list,entlong id)
        {
            if (!list.Contains(id))
            {
                list.Add(id);
            }
            //这里没有解决道具一样的问题
        }

        
    }
}