using System;
using DCFApixels.DragonECS;
using UnityEngine;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/Grid/")]
    [Serializable]
    public struct TilePos:IEcsComponent
    {
        public Vector2Int value;
    }

    [Serializable]
    class TilePosTemplate : ComponentTemplate<TilePos>
    {
    }
}
