using Base;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public class ItemModule:IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new ChangeItemSystem())
                .Add(new ShowItemsSystem())
                .Add(new DeleteOneFrameComponentSystem<ChangeItemEvent>());
        }
    }
}