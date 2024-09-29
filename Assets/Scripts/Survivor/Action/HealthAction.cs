using DCFApixels.DragonECS;

namespace Survivor.Action.Health
{
    /// <summary>
    /// 伤害
    /// </summary>
    public struct Act_Damage : IEcsComponent
    {
        public entlong from;
        public entlong to;
        public int damage;
    }

    /// <summary>
    /// 治疗
    /// </summary>
    public struct Act_Heal : IEcsComponent
    {
        public entlong from;
        public entlong to;
        public int heal;
    }
}