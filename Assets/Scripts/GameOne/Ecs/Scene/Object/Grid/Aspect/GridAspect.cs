using DCFApixels.DragonECS;

//查询
namespace GameOne.Ecs.Map
{
    public class GridAspect:EcsAspect
    {
        public EcsTagPool<GridTag> gridPool = Inc;
        public EcsPool<IndexPosition> positionPool = Inc;
    }
}  