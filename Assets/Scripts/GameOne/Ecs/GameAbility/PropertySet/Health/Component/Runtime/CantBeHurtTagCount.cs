using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [Serializable]
    public partial struct CantBeHurtTagCount : IEcsComponent
    {
        public int count;
    }
    
    public partial struct CantBeHurtTagCount
    {
        public bool CanBeHurt()
        {
            return count == 0;
        }
    }
}