using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [System.Serializable]
    public struct GridContainer:IEcsComponent
    {
        public entlong[,] grids;
    }
}
