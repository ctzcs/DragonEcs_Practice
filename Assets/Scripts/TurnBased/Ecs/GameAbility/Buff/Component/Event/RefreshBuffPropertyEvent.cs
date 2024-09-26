using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public partial struct RefreshBuffPropertyEvent:IEcsComponent
    {
        public enum EChangeType
        {
            Add,
            Remove,
        }

        public EChangeType changeType;
        public entlong needRefreshEntl;
        public entlong changedBuffEntl;
    }
    
    public partial struct RefreshBuffPropertyEvent
    {
        public void Set(EChangeType changeType ,entlong target,entlong buffId)
        {
            this.changeType = changeType;
            this.needRefreshEntl = target;
            this.changedBuffEntl = buffId;
        }
    }
}