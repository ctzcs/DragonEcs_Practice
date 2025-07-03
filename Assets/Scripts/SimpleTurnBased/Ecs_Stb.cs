using System.IO;
using DCFApixels.DragonECS;
using Share.Input;
using Share.Test;
using SimpleTurnBased.Logic;


namespace SimpleTurnBased
{
    public class Ecs_Stb:IEcs
    {
        /// <summary>
        /// 默认世界
        /// </summary>
        private EcsDefaultWorld _world;
        /// <summary>
        /// 事件世界
        /// </summary>
        private EcsEventWorld _eventWorld;
        /// <summary>
        /// 管线
        /// </summary>
        private EcsPipeline _pipeline;
        
        private ServiceHub _serviceHub;

        public EcsDefaultWorld DefaultWorld => _world;

        public EcsEventWorld EventWorld => _eventWorld;
        
        public void Start()
        {
            _world = new EcsDefaultWorld();
            _eventWorld = new EcsEventWorld();
            _serviceHub = new ServiceHub();
            _pipeline = EcsPipeline.New()
                .Inject(_world)
                .Inject(_eventWorld)
                .Inject(_serviceHub)
                .AddModule(new InputModule())
                .AddModule(new LogicModule())
#if UNITY_EDITOR

                .AddModule(new TestModule(Path.Combine(CstStr.Config,CstStr.TestPath, "TestCfg")))
                .AddUnityDebug(_world)
#endif
                .AutoInject().Build();
#if UNITY_EDITOR
            UnityDebugService.Activate();
#endif
            _pipeline.Init();
            
        }
        
        
        public void FixedUpdate()
        {
            _pipeline.FixedRun();
        }

        public void Update()
        {
            _pipeline.Run();
        }
    }
}
