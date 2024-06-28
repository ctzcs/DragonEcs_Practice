using System.Globalization;
using DCFApixels.DragonECS;
using GameOne.Ecs;
using GameOne.Ecs.Input;
using GameOne.Ecs.Process;
using GameOne.Ecs.UnitTest;
using UnityEngine;
using UnityEngine.UI;

namespace GameOne
{
    public class GameMain : MonoBehaviour
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

        /*private EcsUpdateRunner _updateRunner;*/
        private TurnBasedProcessRunner _turnBasedRunner;
        private TimeService _timeService;
        private GameService gameService;
        private float _elapsedTime;
        // Start is called before the first frame update

        
        
        private void Start()
        {
            _world = new EcsDefaultWorld();
            _eventWorld = new EcsEventWorld();
            _timeService = new TimeService();
            gameService = new GameService();
            var e = _world.NewEntity();
            _world.DelEntity(e);
            
            _pipeline = EcsPipeline.New()
                .Inject(_world)
                .Inject(_eventWorld)
                .Inject(_timeService)
                .Inject(gameService)
                .AddModule(new InputModule())
                .AddModule(new GameModule())
                .AddModule(new ViewModule())

                .AddModule(new UnitTestModule())

                .AddUnityDebug(_world,_eventWorld)
                .AutoInject()
                .BuildAndInit();
            
            UnityDebugService.Activate();
            
            _timeService.fixedDeltaTime = 1f;
            //自定义的更新函数
            _turnBasedRunner = _pipeline.GetRunnerInstance<TurnBasedProcessRunner>();
            /*_updateRunner = _pipline.GetRunnerInstance<EcsUpdateRunner>();*/
            
            ChangeTurnEvent.ChangeTurn(_eventWorld,LevelMode.ETurn.RoundStart);
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = _timeService.targetMaxFrame;
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            _timeService.deltaTime = deltaTime;
            _timeService.elapsedTime += deltaTime;
            
            while (_timeService.elapsedTime > _timeService.fixedDeltaTime)
            {
                _pipeline.FixedRun();
                _timeService.elapsedTime -= _timeService.fixedDeltaTime;
                //显示帧率
                ShowFps(deltaTime);
            }
            _pipeline.Run();
            
        }

        /// <summary>
        /// 根据计算跑一回合
        /// </summary>
        public void RunOneTurn()
        {
            //跑一回合
            _turnBasedRunner.RunTurn();
        }
        
        

        public Text fps;

        void ShowFps(float deltaTime)
        {
            fps.text = ((int)(1.0 / deltaTime)).ToString(CultureInfo.CurrentCulture);
        }
    }
}
