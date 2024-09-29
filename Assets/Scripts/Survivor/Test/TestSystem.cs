using System;
using Base;
using DCFApixels.DragonECS;
using Survivor.Global;
using Survivor.Input;

namespace Survivor.Test
{
    [Serializable]
    public class TestSystem:IEcsFixedRunProcess,IEcsRun
    {
        [EcsInject]
        private EcsDefaultWorld _world;

        class Aspect:EcsAspect
        {
            public EcsPool<God> godPool = Inc;
            public EcsPool<GlobalData> globalData = Inc;
        }
        
        public void FixedRun()
        {
            /*ref var input = ref _world.Get<InputData>();
            //EcsDebug.Print(_world.Get<WorldData>().god.Read<God>().name);
            if (input.WasPressed(EKeyCode.A))
            {
                if (input.WasDown(EKeyCode.W))
                {
                    EcsDebug.Print(input.GetRecord(EKeyCode.W).WasPressedInThisFrame);
                    EcsDebug.Print("按下A后按下W"); 
                }
                
            }*/
            
        }

        public void Run()
        {
            ref var input = ref _world.Get<InputData>();
            //EcsDebug.Print(_world.Get<WorldData>().god.Read<God>().name);
            if (input.WasPressed(EKeyCode.A))
            {
                if (input.WasDown(EKeyCode.W))
                {
                    EcsDebug.Print(input.GetRecord(EKeyCode.W).WasPressedInThisFrame);
                    EcsDebug.Print("按下A后按下W"); 
                }
                
            }

        }
    }
}