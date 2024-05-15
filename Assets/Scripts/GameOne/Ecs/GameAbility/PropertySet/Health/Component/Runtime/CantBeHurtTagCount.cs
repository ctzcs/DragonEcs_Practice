using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [Serializable]
    public struct CantBeHurtTagCount : IEcsComponent
    {
        public int count;
    }
}