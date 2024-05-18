using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [Serializable]
    public struct ChangeTurnEvent:IEcsComponent
    {
        public ETurn toTurn;
    }
}