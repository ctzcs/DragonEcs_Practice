using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public struct DeathEvent:IEcsComponent
    {
        public entlong whoEntl;
        public string name;
    }
}