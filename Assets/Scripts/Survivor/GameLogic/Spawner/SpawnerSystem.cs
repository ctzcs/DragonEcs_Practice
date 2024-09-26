
using DCFApixels.DragonECS;

namespace Survivor.GameLogic.Spawner
{
    public class SpawnerSystem:IEcsFixedRunProcess
    {
        [EcsInject] EcsEventWorld _world;

        private class Aspect:EcsAspect
        {
            public EcsPool<Evt_Spawner> spawner;
        }
        public void FixedRun()
        {
            foreach (var evt in _world.Where(out Aspect aspect))
            {
                //通过id将配置的资源创建出来，并分配位置
                
                //添加上AfterSpawnerTag,变成Ready状态，
                
            }
        }
    }
}