﻿using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/BuffModule/")]
    [MetaDescription("Buff移除的时候发生的事情")]
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