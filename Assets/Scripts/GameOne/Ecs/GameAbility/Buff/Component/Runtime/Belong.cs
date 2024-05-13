using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    /// <summary>
    /// buff属于哪个Entity
    /// </summary>
    public struct BelongEntity : IEcsComponent
    {
        /// <summary>
        /// buff属于谁
        /// </summary>
        public entlong belong;
    }
}