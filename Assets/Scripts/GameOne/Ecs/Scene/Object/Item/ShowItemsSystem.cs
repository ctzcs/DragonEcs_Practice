
using DCFApixels.DragonECS;
using GameOne.Ecs;

namespace GameOne
{
    public class ShowItemsSystem:IEcsRun
    {
        [EcsInject]private EcsDefaultWorld _world;
        public void Run()
        {
            foreach (var player in _world.Where(out PlayerAspect playerAspect))
            {
                ref ItemBag item  = ref playerAspect.itemBagPool.Get(player);
                
                if (item.itemIds is null)
                {
                    continue;
                }
                for (int i = 0; i < item.itemIds.Count; i++)
                {
                    item.itemIds[i].Unpack(out int itemId,out EcsWorld world);
                    string name = world.GetPool<Item>().Get(itemId).itemName;
                    EcsDebug.Print($"player 拥有:{name}:{i}");
                    
                }
            }
        }
    }
}