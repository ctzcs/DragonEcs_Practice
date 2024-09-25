using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public struct AddBuffEvent : IEcsComponent 
    {
        public entlong fromEntl;
        public entlong toEntl;
        public entlong buffEntl;
    }
}