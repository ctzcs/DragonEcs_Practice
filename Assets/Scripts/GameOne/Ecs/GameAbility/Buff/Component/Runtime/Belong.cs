using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    /// <summary>
    /// buff属于哪个Entity
    /// </summary>
    [MetaGroup("GameOne/BuffModule/")]
    [Serializable]
    public struct BelongEntity : IEcsComponent
    {
        /// <summary>
        /// buff属于谁
        /// </summary>
        public entlong belongEntl;
    }

    [Serializable]
    class BelongEntityTemplate : ComponentTemplate<BelongEntity>
    {
    }
}