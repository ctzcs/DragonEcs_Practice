using DCFApixels.DragonECS;
using UnityEngine;

namespace GameOne.Ecs
{
    public struct LogicTransform : IEcsComponent
    {
        public Vector3 position;
        public float scaleRate;
    }
}