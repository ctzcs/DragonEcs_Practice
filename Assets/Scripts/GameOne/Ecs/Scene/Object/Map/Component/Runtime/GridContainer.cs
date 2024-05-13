using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/Map/")]
    [System.Serializable]
    public struct GridContainer:IEcsComponent
    {
        public entlong[,] grids;
    }
}
