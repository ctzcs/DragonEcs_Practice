using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/BuffModule/PropertyMod/")]
    [Serializable]
    public partial struct Buff_HealthMod:IEcsComponent
    {
        public int addHealth;
        public int multiHealth;
        
        public int addMaxHealth;
        public int multiMaxHealth;
        
        public int addMinHealth;
        public int multiMinHealth;
    }
    
    [Serializable]
    class Buff_HealthModTemplate:ComponentTemplate<Buff_HealthMod>{}
}