using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/BuffModule/")]
    [Serializable]
    public struct BuffOnAdd : IEcsComponent
    {
        public string funcName;
    }

    [Serializable]
    class BuffOnAddTemplate : ComponentTemplate<BuffOnAdd>
    {
    }
}