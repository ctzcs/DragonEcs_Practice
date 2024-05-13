using Base;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
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
                    string name = item.itemIds[i].Read<Item>().itemName;
                    EcsDebug.Print($"player 拥有:{name}:{i}");
                    
                }
            }
        }
    }
}