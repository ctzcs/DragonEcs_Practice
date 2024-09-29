using System;
using DCFApixels.DragonECS;
using Survivor.GameLogic;
using Survivor.Global;
using Survivor.Input;
using Survivor.Service;
using Survivor.Test;
using UnityEngine;
using ViewModule = Survivor.View.ViewModule;

namespace Survivor
{
    public class Main:MonoBehaviour
    {
        private EcsDefaultWorld _world;
        private EcsPipeline _pipeline;

        private ServiceHub _serviceHub;

        public void Start()
        {
            _world = new EcsDefaultWorld();
            _serviceHub = new ServiceHub();
            _pipeline = EcsPipeline.New()
                .Inject(_world)
                .Inject(_serviceHub)
                .AddModule(new GlobalModule())
                .AddModule(new InputModule())
                .AddModule(new BattleModule())
                .AddModule(new ViewModule())
#if UNITY_EDITOR
                .AddModule(new TestModule())
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