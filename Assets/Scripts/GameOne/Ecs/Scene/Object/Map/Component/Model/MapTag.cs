using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/Map/")]
    public struct MapTag : IEcsTagComponent
    {
    }

    [Serializable]
    class MapTagTemplate : TagComponentTemplate<MapTag>
    {
    }
}