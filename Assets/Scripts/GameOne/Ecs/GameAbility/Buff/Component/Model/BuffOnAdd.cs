using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/BuffModule/")]
    [MetaDescription("Buff添加的时候发生的事情")]
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