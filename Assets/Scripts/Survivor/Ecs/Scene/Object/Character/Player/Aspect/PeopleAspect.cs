using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    //查询
    class PeopleAspect:EcsAspect
    {
        public EcsPool<Health> healthPool = Inc;
        public EcsPool<Name> namePool = Inc;
        public EcsPool<DiffLogic> diffLogicPool = Opt;
    }    
}