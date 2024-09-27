using System;
using DCFApixels.DragonECS;

namespace Survivor.Property
{
    [MetaGroup("Survivor/Property")]
    [Serializable]
    public struct Health:IEcsComponent
    {
        public int health;
        public int maxHealth;
        public int minHealth;
    }
    
    class HealthTemplate : ComponentTemplate<Health>
    {
    }

    public struct Act_Damage : IEcsComponent
    {
        public entlong from;
        public entlong to;
        public int damage;
    }

    public struct Act_Heal : IEcsComponent
    {
        public entlong from;
        public entlong to;
        public int heal;
    }

    public struct Evt_HealthChange
    {
        public entlong target;
        public int preHealth;
        public int nowHealth;
        public int changeHealth;
    }
    
    
}