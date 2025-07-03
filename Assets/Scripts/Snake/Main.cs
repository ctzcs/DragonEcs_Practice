using System.IO;
using DCFApixels.DragonECS;
using Share.Input;
using Share.Test;
using UnityEngine;

namespace Snake
{
    public class Main : MonoBehaviour
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
        
        public void Start()
        {
            _world = new EcsDefaultWorld();
            _serviceHub = new ServiceHub();
            _pipeline = EcsPipeline.New()
                .Inject(_world)
                .Inject(_serviceHub)
                .AddModule(new InputModule())
#if UNITY_EDITOR
                .AddModule(new TestModule(Path.Combine(CstStr.TestPath,CstStr.Config,"TestCfg")))
                .AddUnityDebug(_world)
#endif
                .AutoInject().Build();
            //初始化游戏
            Init();
        }



        void Init()
        {
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
