
using Base;
using DCFApixels.DragonECS;


namespace Survivor.Actor
{
    public class AddToKdTreeSystem:IEcsRun
    {
        [EcsInject] private EcsDefaultWorld _world;
        class Aspect:EcsAspect
        {
            public EcsPool<Evt_AddToKdTree> AddToKdTree = Inc;
        }
        public void Run()
        {
            //给实体添加KdAgent
            foreach (var evt in _world.Where(out Aspect aspect))
            {
                ref readonly var evtInfo = ref aspect.AddToKdTree.Read(evt);
                KdAgent agent = new KdAgent();
                evtInfo.target.Add(ref agent);
            }
        }
    }
}