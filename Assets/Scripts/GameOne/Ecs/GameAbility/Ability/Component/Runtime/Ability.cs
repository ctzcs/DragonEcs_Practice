using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [System.Serializable]
    public struct Ability:IEcsComponent
    {
        /// <summary>
        /// 锁住了就不能用
        /// </summary>
        public bool locked;
    }
}
