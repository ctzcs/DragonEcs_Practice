using System;
using System.Collections.Generic;
using DCFApixels.DragonECS;
using UnityEngine.Serialization;

namespace GameOne.Ecs
{
    [Serializable]
    [MetaGroup("GameOne/BuffModule/")]
    public partial struct CarryBuffs:IEcsComponent
    {
        public List<entlong> buffEntlList;
    }


    [Serializable]
    class CarryBuffsTemplate : ComponentTemplate<CarryBuffs>
    {
    }

    public partial struct CarryBuffs
    {
        public void AddBuff(entlong id)
        {
            buffEntlList.Add(id);
        }

        public void RemoveBuff(entlong id)
        {
            buffEntlList.Remove(id);
        }
    }
}