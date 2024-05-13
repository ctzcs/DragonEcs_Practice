using System;
using DCFApixels.DragonECS;
using UnityEngine;

namespace GameTwo
{
    [Serializable]
    [MetaGroup("GameTwo/TileBase/")]
    public struct TileDir:IEcsComponent
    {
        public Vector2Int dir;
    }

    [Serializable]
    class TileDirTemplate:ComponentTemplate<TileDir>
    {
        
    }
}
