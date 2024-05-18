using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/BuffModule/")]
    [Serializable]
    public struct BuffOnRemove : IEcsComponent
    {
        public string funcName;
    }

    [Serializable]
    class BuffOnRemoveTemplate : ComponentTemplate<BuffOnRemove>
    {
    }
}