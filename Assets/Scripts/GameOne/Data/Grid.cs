using System;
using UnityEngine;

namespace GameOne.Data
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