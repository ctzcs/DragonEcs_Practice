using DCFApixels.DragonECS;
using UnityEngine;

namespace GameOne.Ecs
{
    public class TurnBasedSystem : IEcsInit,IEcsFixedRunProcess
    {
        [EcsInject] EcsDefaultWorld _world;
        [EcsInject] private EcsEventWorld _eWorld;
        private GameMain _main;
        
        public void Init()
        {
            _main = GameObject.Find("Main").GetComponent<GameMain>();
        }

        class Aspect:EcsAspect
        {
            public EcsPool<RoundStartEvent> RoundStartPool = Inc;
        }
        
        public void FixedRun()
        {
            foreach (var roundStart in _eWorld.Where(out Aspect aspect))
            {
                CheckTurn();
            }
        }

        void CheckTurn()
        {
            _main.RunOneTurn();
            
        }

        

        
        
        
        
    }
}