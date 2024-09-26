using DCFApixels.DragonECS;


namespace GameOne.Ecs
{
    public class InitMapSystem : IEcsFixedRunProcess
    {
        [EcsInject] private EcsDefaultWorld _world;
        [EcsInject]private EcsEventWorld _eWorld;

        class Aspect:EcsAspect
        {
            public EcsPool<CreateMapEvent> createMapEvents = Inc;
        }
        
        public void FixedRun()
        {
            foreach (var id in _eWorld.Where(out Aspect aspect))
            {
                var newMap = _world.NewEntity();
                ref var createMapEvent = ref aspect.createMapEvents.Get(id);
                _world.GetTagPool<MapTag>().Add(newMap);
                ref MapModel mapModel = ref _world.GetPool<MapModel>().Add(newMap);
                mapModel.Set(createMapEvent.width,createMapEvent.height);
                
            }
        }
    }
}
