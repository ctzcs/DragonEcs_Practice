using DCFApixels.DragonECS;

//查询
namespace GameOne.Ecs
{
    public class GridAspect:EcsAspect
    {
        public EcsTagPool<GridTag> gridPool = Inc;
        public EcsPool<TilePos> positionPool = Inc;
    }
}  