using System;
using DCFApixels.DragonECS;
using GameOne.General;

namespace GameOne.Ecs
{
    [Serializable]
    public partial struct Health:IEcsComponent
    {
        /// <summary>
        /// 健康值
        /// </summary>
        public int healthValue;
        public int addHealth;
        public int multiHealth;
        
        public int minHealthValue;
        public int addMinHealth;
        public int multiMinHealth;
                        
        public int maxHealthValue;
        public int addMaxHealth;
        public int multiMaxHealth;
    }
    
    public partial struct Health:IAddable<Buff_HealthMod>,ISubtract<Buff_HealthMod>
    {
        public void Add(Buff_HealthMod other)
        {
            addHealth += other.addHealth;
            multiHealth += other.multiHealth;
            
            addMaxHealth += other.addMaxHealth;
            multiMaxHealth += other.multiMaxHealth;
            
            addMinHealth += other.addMinHealth;
            multiMinHealth += other.multiMinHealth;
        }

        public void Subtract(Buff_HealthMod other)
        {
            addHealth -= other.addHealth;
            multiHealth -= other.multiHealth;
            
            addMaxHealth -= other.addMaxHealth;
            multiMaxHealth -= other.multiMaxHealth;
            
            addMinHealth -= other.addMinHealth;
            multiMinHealth += other.multiMinHealth;
        }
    }
}