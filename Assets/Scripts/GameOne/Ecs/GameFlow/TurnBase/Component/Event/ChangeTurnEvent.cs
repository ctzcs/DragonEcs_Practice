using System;
using Base;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [Serializable]
    public partial struct ChangeTurnEvent:IEcsComponent
    {
        public ETurn toTurn;
    }
    
    public partial struct ChangeTurnEvent
    {
        public static void ChangeTurn(EcsWorld world,ETurn toTurn)
        {
            var e= world.NewEntityLong();
            e.TryGetOrAdd<ChangeTurnEvent>().toTurn = ETurn.RoundStart;
        }
    }
}