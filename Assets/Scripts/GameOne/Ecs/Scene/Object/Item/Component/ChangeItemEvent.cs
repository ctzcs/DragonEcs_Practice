using System;
using DCFApixels.DragonECS;

namespace GameOne
{
    [Serializable]
    public struct ChangeItemEvent:IEcsComponent
    {
        public enum EAddOrRemove
        {
            Add,
            Remove,
        }

        public EAddOrRemove operation;
        public entlong who;
        public entlong item;
    }
    
    
}