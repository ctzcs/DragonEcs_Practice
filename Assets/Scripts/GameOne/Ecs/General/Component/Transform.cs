using DCFApixels.DragonECS;
using UnityEngine;

namespace GameTwo
{
    [System.Serializable]
    public struct Transform:IEcsComponent
    {
        public Vector2Int position;
        public Vector2Int dir;
    }
}
