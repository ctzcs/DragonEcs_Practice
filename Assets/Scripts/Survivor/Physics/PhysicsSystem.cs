using DCFApixels.DragonECS;
using Survivor.Service;

namespace Survivor.Physics
{
    public class PhysicsSystem:IEcsInit,IEcsFixedRunProcess
    {
        [EcsInject] private ServiceHub _serviceHub;
        
        public void Init()
        {
            _serviceHub.PhysicsWorld.Init();
        }
        public void FixedRun()
        {
            //处理box
            //处理circle
            _serviceHub.PhysicsWorld.Step();
        }

       
    }


    
}



