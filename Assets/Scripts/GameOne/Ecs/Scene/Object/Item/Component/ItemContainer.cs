using System;
using System.Collections.Generic;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [Serializable]
    public struct ItemContainer:IEcsComponent
    {
        public List<entlong> itemIds;
    }
}
