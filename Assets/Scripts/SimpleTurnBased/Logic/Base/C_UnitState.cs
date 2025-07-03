using DCFApixels.DragonECS;

namespace SimpleTurnBased.Logic.Base
{
    public struct C_UnitState : IEcsComponent
    {
        public bool isAlive;//是否活着->死了一定无效
        public bool isValid;//是否有效->无效代表任何效果对他不起作用，不受到伤害，不影响其他对象
        public bool isShow;//是否显示->死了一定不显示
        public bool hasVolume;//是否有碰撞体积，如果无体积，代表不占用格子
        
    }
}