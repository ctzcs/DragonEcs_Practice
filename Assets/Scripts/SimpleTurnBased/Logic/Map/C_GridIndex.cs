using DCFApixels.DragonECS;
using UnityEngine;

namespace SimpleTurnBased.Logic.Map
{
    public struct C_GridIndex:IEcsComponent
    {
        public ELayer layer;
        public Vector2Int index;
    }
}