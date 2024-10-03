using DCFApixels.DragonECS;
using Unity.Mathematics;
using UnityEngine;

namespace Survivor.Physics
{
    public struct CircleCollider:IEcsComponent
    {
        public int index;
        public int cellIndex;
        public float radius;
        public float2 position;
        public bool collided;
        public bool trigger;
        /*public CollisionLayer layer;
        public CollisionLayer collideWith;*/
        public Vector3 offset;
        public override int GetHashCode() {
            return index;
        }

        public bool Equals(CircleCollider other) {
            return other.index == index;
        }
    }
}