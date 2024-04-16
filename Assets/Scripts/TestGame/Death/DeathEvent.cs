using DCFApixels.DragonECS;

namespace Component
{
    public struct DeathEvent:IEcsComponent
    {
        public entlong who;
        public string name;
    }
}