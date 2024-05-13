using System;
using DCFApixels.DragonECS;
using UnityEngine;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/Grid/")]
    [Serializable]
    public struct IndexPosition:IEcsComponent
    {
        public Vector2Int value;
    }

    [Serializable]
    class IndexPositionTemplate : ComponentTemplate<IndexPosition>
    {
    }
}
