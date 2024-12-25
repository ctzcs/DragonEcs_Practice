namespace DCFApixels.DragonECS.On.Internal
{
    public static class EcsOnConsts
    {
        public const string RECURSIVE_LAYER = nameof(RECURSIVE_LAYER);
        public const string POST_RECURSIVE_LAYER = nameof(POST_RECURSIVE_LAYER);
    }
    internal class RunRecursiveSystem : IEcsInit, IEcsRun, IEcsPipelineMember, IEcsModule
    {
        private int CRITICAL_RECURSIVE_COUNT = 100000;
        public EcsPipeline Pipeline { get; set; }

        EcsProcess<IRecursive> _process;
        private long _runVersion = 0;
        public void Init()
        {
            _process = Pipeline.GetProcess<IRecursive>();
        }
        public void Run()
        {
            bool isLoop = false;
            foreach (var system in _process)
            {
                if (system.RunRecursive(_runVersion))
                {
                    isLoop = true;
                }
            }
            _runVersion++;
            if (isLoop)
            {
                if (_runVersion >= CRITICAL_RECURSIVE_COUNT)
                {
                    EcsDebug.PrintWarning("Критическое зацикливание");
                }
                else
                {
                    Run();
                }
            }
            _runVersion = 0;
        }

        public void Import(EcsPipeline.Builder b)
        {
            b.Layers.InsertAfter(EcsConsts.BASIC_LAYER, EcsOnConsts.RECURSIVE_LAYER, EcsOnConsts.POST_RECURSIVE_LAYER);
        }
    }
    public interface IRecursive : IEcsProcess
    {
        public bool RunRecursive(long runVersion);
    }
}
