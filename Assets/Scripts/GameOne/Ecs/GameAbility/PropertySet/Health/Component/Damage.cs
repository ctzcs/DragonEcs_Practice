using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
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