using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public class RemoveBuffSystem<T> : IEcsFixedRunProcess where T:struct,IEcsComponent
    {
        [EcsInject] EcsDefaultWorld _world;

        class Aspect:EcsAspect
        {
            public EcsPool<LastRound> lastRoundPool = Inc;
            
        }
        public void FixedRun()
        {
        }
    }
}