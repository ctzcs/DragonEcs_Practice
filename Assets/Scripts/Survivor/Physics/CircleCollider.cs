using DCFApixels.DragonECS;
using Unity.Mathematics;
using UnityEngine;

namespace Survivor.Physics
{
    [MetaGroup("Survivor/Physics/Collider")]
    public struct CircleCollider:IEcsComponent
    {
        public float2 offset;
        public float radius;
        public CollisionLayer layer;
        public CollisionLayer collideWith;
        
        //NoConfig
        public int index;
        public float2 center;
        public Bounds Bounds;
        public override int GetHashCode() {
            return index;
        }

        public bool Equals(CircleCollider other) {
            return other.index == index;
        }
    }
}