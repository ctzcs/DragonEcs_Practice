using System.Collections.Generic;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [System.Serializable]
    public struct OwnedAbilities:IEcsComponent
    {
        public Dictionary<int, entlong> ownedAbilityDic;
    }
}
