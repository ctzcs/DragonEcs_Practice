using System;
using UnityEngine;

namespace GameOne.Struct
{
    [Serializable]
    public struct Grid
    {
        public Vector2Int pos;
        public string name;
        public string surface;
        public string ground;
    }
}