using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/Character/AI/")]
    [MetaDescription("AI的标签")]
    [Serializable]
    public struct MonsterTag:IEcsTagComponent{ }

    [Serializable]
    class MonsterTagTemplate : TagComponentTemplate<MonsterTag>
    {
    }
}
