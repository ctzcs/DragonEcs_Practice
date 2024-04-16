using DCFApixels.DragonECS;
using Module;
using Object;
using UnityEngine;

public class TestGame : MonoBehaviour
{
    private EcsDefaultWorld _world;
    private EcsEventWorld _eventWorld;
    private EcsPipeline _pipeline;
    private TimeService _timeService;
    private GameStateService _gameStateService;
    private float _elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        _world = new EcsDefaultWorld();
        _eventWorld = new EcsEventWorld();
        _timeService = new TimeService();
        _gameStateService = new GameStateService();
        var e = _world.NewEntity();
        _world.DelEntity(e);
        _pipeline = EcsPipeline.New()
           .AddModule(new TestModule())
           .AddUnityDebug(_world,_eventWorld)
           //注入
           .Inject(_world)
           .Inject(_eventWorld)
           .Inject(_timeService)
           .Inject(_gameStateService)
           .AutoInject()
           .BuildAndInit();
        UnityDebugService.Activate();
        _timeService.fixedDeltaTime = 1f;
    }

    private void Update()
    {
        _timeService.elapsedTime += Time.deltaTime;
        if (_timeService.elapsedTime > _timeService.fixedDeltaTime)
        {
            _pipeline.Run();
            _timeService.elapsedTime -= _timeService.fixedDeltaTime ;
        }
    }

    
}
