using DCFApixels.DragonECS;

namespace GameTwo
{
    [System.Serializable]
    public struct DamageTarget:IEcsComponent
    {
        /// <summary>
        /// 伤害多少值
        /// </summary>
        public int value;
    }
}
