using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/Map/")]
    [MetaDescription("格子容器，用来存放所有的格子")]
    [System.Serializable]
    public struct GridContainer:IEcsComponent
    {
        public entlong[,] grids;
    }
}
