using DCFApixels.DragonECS.On.Internal;

namespace DCFApixels.DragonECS
{
    [MetaName("On")]
    [MetaColor(MetaColor.BlueViolet)]
    [MetaTags(MetaTags.HIDDEN)]
    public class RunOnSystem<T, TWorld> : IRecursive, IEcsPipelineMember, IEcsInject<TWorld>
        where T : struct, IEcsComponent
        where TWorld : EcsWorld
    {
        private EcsWorld _world;
        void IEcsInject<TWorld>.Inject(TWorld obj) => _world = obj;
        private int _maxLoops;
        public RunOnSystem(int maxLoops = -1)
        {
            _maxLoops = maxLoops;
        }
        public EcsPipeline Pipeline { get; set; }

        class Aspect : EcsAspect
        {
            public EcsPool<T> values = Inc;
        }
        private long _lastRunVersion = -1;
        private int _currentRunLoops = 0;
        public bool RunRecursive(long runVersion)
        {
            if (_lastRunVersion != runVersion)
            {
                _currentRunLoops = 0;
                _lastRunVersion = runVersion;
            }
            else
            {
                if (_maxLoops >= 0)
                {
                    if (_currentRunLoops >= _maxLoops)
                    {
                        return false;
                    }
                    _currentRunLoops++;
                }
            }
            EcsSpan events = _world.Where(out Aspect a);
            if (events.Count != 0)
            {
                Pipeline.GetRunnerInstance<IOnRunner<T>>().ToRun(events);
                foreach (var e in events)
                {
                    a.values.TryDel(e);
                }
                return true;
            }
            return false;
        }
    }
}
