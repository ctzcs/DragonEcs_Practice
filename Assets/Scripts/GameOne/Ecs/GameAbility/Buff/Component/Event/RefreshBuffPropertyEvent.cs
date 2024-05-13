using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public partial struct RefreshBuffPropertyEvent:IEcsComponent
    {
        public entlong refreshTarget;
        public entlong refreshBuffId;
    }
    
    public partial struct RefreshBuffPropertyEvent
    {
        public void Set(entlong target,entlong buffId)
        {
            this.refreshTarget = target;
            this.refreshBuffId = buffId;
        }
    }
}