using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/TimeModule/")]
    [Serializable]
    public struct LastRound : IEcsComponent
    {
        public int round;
    }

    [Serializable]
    class LastRoundTemplate : ComponentTemplate<LastRound>
    {
    }
}