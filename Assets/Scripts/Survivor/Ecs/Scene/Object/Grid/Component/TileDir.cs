using System;
using DCFApixels.DragonECS;
using UnityEngine;

namespace GameOne.Ecs
{
    [Serializable]
    [MetaGroup("GameOne/Grid/")]
    [MetaDescription("对象朝向的方向")]
    public struct TileDir:IEcsComponent
    {
        public Vector2Int dir;
    }

    [Serializable]
    class TileDirTemplate:ComponentTemplate<TileDir>
    {
        
    }
}
