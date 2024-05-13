using System.Collections.Generic;
using DCFApixels.DragonECS;

namespace Base
{
    [MetaTags(MetaTags.HIDDEN)]
    [MetaColor(MetaColor.Grey)]
    public class DeleteOneFrameComponentSystem<TComponent> : IEcsFixedRunProcess, IEcsInject<EcsWorld>
        where TComponent : struct, IEcsComponent
    {
        public EcsPipeline pipeline { get; set; }
        private sealed class Aspect : EcsAspect
        {
            public EcsPool<TComponent> pool = Inc;
        }
        private readonly List<EcsWorld> _worlds = new List<EcsWorld>();
        public void Inject(EcsWorld obj) => _worlds.Add(obj);
        public void FixedRun()
        {
            for (int i = 0, iMax = _worlds.Count; i < iMax; i++)
            {
                EcsWorld world = _worlds[i];
                if (world.IsComponentTypeDeclared<TComponent>())
                {
                    foreach (var e in world.WhereToGroup(out Aspect a))
                        a.pool.Del(e);
                }
            }
        }
    }
    public static class DeleteOneFrameComponentSystemExtensions
    {
        private const string AUTO_DEL_LAYER = nameof(AUTO_DEL_LAYER);
        public static EcsPipeline.Builder AutoDel<TComponent>(this EcsPipeline.Builder b, string layerName = AUTO_DEL_LAYER)
            where TComponent : struct, IEcsComponent
        {
            if (AUTO_DEL_LAYER == layerName)
                b.Layers.InsertAfter(EcsConsts.POST_END_LAYER, AUTO_DEL_LAYER);
            b.AddUnique(new DeleteOneFrameComponentSystem<TComponent>(), layerName);
            return b;
        }
    }
}