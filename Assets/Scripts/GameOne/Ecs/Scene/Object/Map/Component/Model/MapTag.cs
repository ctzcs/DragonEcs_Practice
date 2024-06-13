using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/Map/")]
    [Serializable]
    [MetaDescription("地图的标签")]
    public struct MapTag : IEcsTagComponent
    {
    }

    [Serializable]
    class MapTagTemplate : TagComponentTemplate<MapTag>
    {
    }
}