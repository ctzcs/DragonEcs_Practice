using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/Character/Player/")]
    [Serializable]
    public struct PlayerTag:IEcsTagComponent{}

    [Serializable]
    class PlayerTagTemplate : TagComponentTemplate<PlayerTag>
    { }
}