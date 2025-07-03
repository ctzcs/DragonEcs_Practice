using System.Globalization;
using Base;
using DCFApixels.DragonECS;

namespace SimpleTurnBased.Logic.Player
{
    public class S_PlayerGenerator:IEcsFixedRunProcess
    {
        [DI] private EcsDefaultWorld _world;
        [DI] private EcsEventWorld _eWorld;
        class Aspect : EcsAspect
        {
            public EcsPool<Ce_GenPlayer> genPlayer = Inc;
        }
        public void FixedRun()
        {
            foreach (var ent in _eWorld.Where(out Aspect aspect))
            {
                //ent.Get()
            }
        }
    }
}