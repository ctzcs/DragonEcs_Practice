using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public struct HealthChangeEvent:IEcsComponent
    {
        /// <summary>
        /// 伤害来源
        /// </summary>
        public entlong fromEntl;
        /// <summary>
        /// 伤害目标
        /// </summary>
        public entlong toEntl;

        /// <summary>
        /// 伤害值/治疗值
        /// </summary>
        public int changeValue;
    }
}