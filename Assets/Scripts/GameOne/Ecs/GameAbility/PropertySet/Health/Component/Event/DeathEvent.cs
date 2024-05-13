using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public struct DeathEvent:IEcsComponent
    {
        public entlong who;
        public string name;
    }
}