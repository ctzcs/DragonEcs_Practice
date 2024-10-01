using DCFApixels.DragonECS;
using UnityEngine;

namespace Survivor.Physics
{
    public struct BoxCollider:IEcsComponent
    {
        public Vector3 min;
        public Vector3 max;
    }
}