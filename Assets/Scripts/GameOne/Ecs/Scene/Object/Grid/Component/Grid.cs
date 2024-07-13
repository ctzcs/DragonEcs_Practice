using System;
using System.Collections.Generic;
using DCFApixels.DragonECS;
using UnityEngine;

namespace GameOne.Ecs
{
    [Serializable]
    public struct Grid:IEcsComponent
    {
        public Vector2Int pos;
        public string name;
        public List<entlong> container;
    }
}