using DCFApixels.DragonECS;
using UnityEngine;

namespace Survivor.Physics
{
    public struct CircleCollider:IEcsComponent
    {
        public Vector3 offset;
        public float radius;
    }
}