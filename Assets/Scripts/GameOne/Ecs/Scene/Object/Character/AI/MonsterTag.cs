using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/Character/AI/")]
    [Serializable]
    public struct MonsterTag:IEcsTagComponent{ }

    [Serializable]
    class MonsterTagTemplate : TagComponentTemplate<MonsterTag>
    {
    }
}
