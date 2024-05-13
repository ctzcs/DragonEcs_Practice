using System.Collections.Generic;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [System.Serializable]
    public partial struct CarryBuffs:IEcsComponent
    {
        public List<entlong> buffs;
    }


    public partial struct CarryBuffs
    {
        public void AddBuff(entlong id)
        {
            buffs.Add(id);
        }

        public void RemoveBuff(entlong id)
        {
            buffs.Remove(id);
        }
    }
}