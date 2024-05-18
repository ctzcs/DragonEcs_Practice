using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/BuffModule/PropertyMod/")]
    [Serializable]
    public struct CantBeHurtTag : IEcsTagComponent
    {
    }

    [Serializable]
    class CantBeHurtTagTemplate:TagComponentTemplate<CantBeHurtTag> { }
}