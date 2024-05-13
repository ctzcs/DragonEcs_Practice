using System;
using DCFApixels.DragonECS;
using UnityEngine;

namespace GameTwo
{
    [Serializable][MetaGroup("GameTwo/TileBase/")]
    
    public struct TilePos:IEcsComponent
    {
        public Vector2Int pos;
    }
    [Serializable]
    class TilePosTemplate:ComponentTemplate<TilePos>
    {
    }
}
