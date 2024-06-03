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
        private EcsDefaultWorld _world;
        private EcsEventWorld _eventWorld;
        private EcsPipeline _pipline;

        /*private EcsUpdateRunner _updateRunner;*/
        private TurnBasedProcessRunner _turnBasedRunner;
        private TimeService _timeService;
        private GameStateService _gameStateService;
        private float _elapsedTime;
        // Start is called before the first frame update

        
        
        private void Start()
        {
            _world = new EcsDefaultWorld();
            _eventWorld = new EcsEventWorld();
            _timeService = new TimeService();
            _gameStateService = new GameStateService();
            var e = _world.NewEntity();
            _world.DelEntity(e);
            
            _pipline = EcsPipeline.New()
                .Inject(_world)
                .Inject(_eventWorld)
                .Inject(_timeService)
                .Inject(_gameStateService)
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
            _turnBasedRunner = _pipline.GetRunnerInstance<TurnBasedProcessRunner>();
            /*_updateRunner = _pipline.GetRunnerInstance<EcsUpdateRunner>();*/
            
            ChangeTurnEvent.ChangeTurn(_eventWorld,ETurn.RoundStart);
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
                _pipline.FixedRun();
                _timeService.elapsedTime -= _timeService.fixedDeltaTime;
                //显示帧率
                ShowFps(deltaTime);
            }
            _pipline.Run();
            
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
