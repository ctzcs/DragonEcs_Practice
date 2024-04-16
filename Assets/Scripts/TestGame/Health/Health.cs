using System;
using DCFApixels.DragonECS;

namespace Component
{
    [Serializable]
    public struct Health:IEcsComponent
    {
        /// <summary>
        /// 健康值
        /// </summary>
        public int health;
    }
}