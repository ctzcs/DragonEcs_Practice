using Base;
using DCFApixels.DragonECS;
using GameOne.Ecs;
using GameOne.Ecs.Input;
using GameOne.Ecs.UnitTest;
using UnityEngine;

namespace GameOne
{
    public class GameMain : MonoBehaviour
    {
        private EcsDefaultWorld _world;
        private EcsEventWorld _eventWorld;
        private EcsPipeline _pipline;

        private EcsUpdateRunner _updateRunner;
        
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
                .AddModule(new GodModule())
                .AddModule(new MapModule())
                .AddModule(new HealthModule())
                .AddModule(new ItemModule())
                .AddModule(new BuffModule())
#if UNITY_EDITOR
                .AddModule(new UniTestModule())
#endif
                .AddUnityDebug(_world,_eventWorld)
                .AutoInject()
                .BuildAndInit();
            
            UnityDebugService.Activate();
            _timeService.fixedDeltaTime = 1f;
            //自定义的更新函数
            _updateRunner = _pipline.GetRunnerInstance<EcsUpdateRunner>();
        }

        private void Update()
        {
            
            /*_updateRunner.Update();*/
            _pipline.Run();
            _timeService.elapsedTime += Time.deltaTime;
            if (_timeService.elapsedTime > _timeService.fixedDeltaTime)
            {
                _pipline.FixedRun();
                _timeService.elapsedTime -= _timeService.fixedDeltaTime ;
            }
            
        }

        
       
    
    }
}
