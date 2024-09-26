using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/Character/Player/")]
    [MetaDescription("玩家标签，用来标识玩家")]
    [Serializable]
    public struct PlayerTag:IEcsTagComponent{}

    [Serializable]
    class PlayerTagTemplate : TagComponentTemplate<PlayerTag>
    { }
}