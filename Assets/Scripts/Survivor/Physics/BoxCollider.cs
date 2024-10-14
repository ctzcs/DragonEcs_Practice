using System;
using DCFApixels.DragonECS;
using Unity.Mathematics;

namespace Survivor.Physics
{
    [MetaGroup("Survivor/Physics/Collider")]
    [Serializable]
    public struct BoxCollider:IEcsComponent
    {
        public float2 offset;
        public float width;
        public float height;
        public CollisionLayer layer;
        public CollisionLayer collideWith;
        
        //NoConfig
        public int index;
        public float2 center;
        public Bounds bounds;
        public bool Equals(CircleCollider other) {
            return other.index == index;
        }
    }

    [Serializable]
    class BoxColliderTemplate : ComponentTemplate<BoxCollider>
    {
    }
    
    
}