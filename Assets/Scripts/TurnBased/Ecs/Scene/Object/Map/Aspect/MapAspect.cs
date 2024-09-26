using DCFApixels.DragonECS;

//查询
namespace GameOne.Ecs.Map
{
    public class MapAspect:EcsAspect
    {
        public EcsPool<GridContainer> gridContainerPool = Inc;
        public EcsTagPool<MapTag> mapTagPool = Inc;
    }
}  