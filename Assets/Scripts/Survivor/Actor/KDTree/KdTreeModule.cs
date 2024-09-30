using Base;
using DCFApixels.DragonECS;

namespace Survivor.Actor
{
    public class KdTreeModule:IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            //添加到树
            //重建树
            b.Add(new AddToKdTreeSystem(), EcsConsts.END_LAYER)
                .Add(new KdTreeSystem(), EcsConsts.END_LAYER)
                .AutoDel<Evt_AddToKdTree>();
        }
    }
}