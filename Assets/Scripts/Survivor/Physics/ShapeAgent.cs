using System;
using DCFApixels.DragonECS;
using Service;
using Unity.Mathematics;
using UnityEngine;

namespace Survivor.Physics
{
    //Bvh组件
    [MetaGroup("Survivor/Physics")]
    [Serializable]
    public struct PhysicsBvhAgent:IEcsComponent
    {
        public Rect bounds;
        //和oop交互
        public BvhAgent agent;
    }

    [Serializable]
    class ShapeAgentTemplate : ComponentTemplate<PhysicsBvhAgent>
    {
    }
    
    
    public enum EShape
    {
        Box,
        Circle,
    }
    
    [Serializable]
    public class BoxAgent:IShape
    {
        private float _width;
        private float _height;
        private Rect _bounds;
        private float2 _position;
        
        public bool RemoveTag { get; set; }
        public Rect Bounds 
        { 
            get =>_bounds;
            set => _bounds = value;
        }

        public float2 Position
        {
            get => _position;
            set
            {
                _position = value;
                _bounds.center = value;
            }
        }

        public CollisionLayer Layer { get; }
        public CollisionLayer CollideWith { get; }

        public BoxAgent(Vector2 position,float width, float height,CollisionLayer layer,CollisionLayer collideWith)
        {
            _width = width;
            _height = height;
            _bounds = new Rect(position.x,position.y,width,height);
            _position = position;
            
        }
    }

    [Serializable]
    public class CircleAgent : IShape
    {
        private float _radius;
        private Rect _bounds;
        private float2 _position;
        
        public bool RemoveTag { get; set; }
        public Rect Bounds 
        { 
            get =>_bounds;
            set => _bounds = value; }
        public float2 Position
        {
            get => _position;
            set
            {
                _position = value;
                _bounds.center = value;
            }
        }

        public CollisionLayer Layer { get; }
        public CollisionLayer CollideWith { get; }

        public CircleAgent(Vector2 position, float radius)
        {
            _position = position;
            _radius = radius;
            _bounds = new Rect(position,new Vector2(radius*2,radius*2));
        }
        
    }
}