using System.Collections.Generic;
using DCFApixels.DragonECS;

namespace GameTwo
{
    [System.Serializable]
    public struct OwnBuffs:IEcsComponent
    {
        public List<entlong> buffs;
    }
}
