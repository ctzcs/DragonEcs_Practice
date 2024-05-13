using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public struct AddBuffEvent : IEcsComponent 
    {
        public entlong from;
        public entlong to;
        public entlong buffEntity;
    }
}