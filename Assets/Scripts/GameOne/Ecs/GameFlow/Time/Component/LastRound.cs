using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/TimeModule/")]
    [MetaDescription("该仍能实体存活的回合")]
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