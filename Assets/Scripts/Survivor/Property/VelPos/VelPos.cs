using System;
using DCFApixels.DragonECS;
using UnityEngine;


namespace Survivor.Property
{
    [MetaGroup("Survivor/Property")]
    [Serializable]
    public struct VelPos : IEcsComponent
    {
        public Vector3 velocity;
        public Vector3 position;
        public float scaleRate;
    }
}