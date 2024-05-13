
using DCFApixels.DragonECS;

namespace GameTwo
{
    [System.Serializable]
    [MetaGroup("GameTwo/MapModule/")]
    public struct MapGridContainer:IEcsComponent
    {
        public int width;
        public int height;
        public entlong[,] grids;
    }

    [System.Serializable]
    class MapGridContainerTemplate:ComponentTemplate<MapGridContainer>
    {
        
    }
}
