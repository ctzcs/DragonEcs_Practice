
using DCFApixels.DragonECS;

namespace Survivor.GameLogic
{
    public class SpawnerSystem:IEcsFixedRunProcess
    {
        [EcsInject]private EcsWorld _world;
        private class Aspect:EcsAspect
        {
            public EcsPool<Act_Spawn> spawner;
        }
        public void FixedRun()
        {
            foreach (var evt in _world.Where(out Aspect aspect))
            {
                //通过id将配置的资源创建出来，并分配位置
                
                //如果创建成功，发送创建成功事件
                
            }
        }
    }
}