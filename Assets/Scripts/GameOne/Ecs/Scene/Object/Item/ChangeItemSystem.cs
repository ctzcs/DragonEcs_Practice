using System.Collections.Generic;
using DCFApixels.DragonECS;

namespace GameOne
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
            foreach (var id in _eventWorld.Where(out ChangeItemAspect aspect))
            {
                ChangeItemEvent changeItemEvent = aspect.changeItemEventPool.Get(id);
                entlong whoEntLong = changeItemEvent.who;
                entlong itemEntLong = changeItemEvent.item;
                
                whoEntLong.Unpack(out int whoId,out EcsWorld whoWorld);
                if (!whoWorld.GetPool<ItemBag>().Has(whoId))
                {
                    continue;
                }

                ItemBag itemBag = whoWorld.GetPool<ItemBag>().Get(whoId);
                
                switch (changeItemEvent.operation)
                {
                    case ChangeItemEvent.EAddOrRemove.Add:
                        AddItem(itemBag.itemIds,itemEntLong);
                        break;
                    case ChangeItemEvent.EAddOrRemove.Remove:
                        RemoveItem(itemBag.itemIds,itemEntLong);
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