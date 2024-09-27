using System;
using DCFApixels.DragonECS;
using UnityEngine;

namespace Survivor.Property
{
    [MetaGroup("Survivor/Property")]
    [Serializable]
    public struct VelPos : IEcsComponent
    {
        public Vector2 velocity;
        public Vector2 pos;
    }
}