using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public struct HealthChangeEvent:IEcsComponent
    {
        /// <summary>
        /// 伤害来源
        /// </summary>
        public entlong fromEntity;
        /// <summary>
        /// 伤害目标
        /// </summary>
        public entlong toEntity;

        /// <summary>
        /// 伤害值/治疗值
        /// </summary>
        public int changeValue;
    }
}