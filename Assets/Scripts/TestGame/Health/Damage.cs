using System;
using DCFApixels.DragonECS;

namespace Component
{
    [Serializable]
    public struct Damage : IEcsComponent
    {
        /// <summary>
        /// 伤害值
        /// </summary>
        public int damage;
    }
}