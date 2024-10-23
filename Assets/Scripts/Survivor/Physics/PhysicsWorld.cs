using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DCFApixels.DragonECS;
using NUnit.Framework;
using Unity.Mathematics;
using UnityEngine;
using Utility;
using Random = UnityEngine.Random;


namespace Survivor.Physics
{
    public partial class PhysicsWorld
    {
        private QuadTree<IShape> _quadTree;
        
        private Dictionary<int, IShape> _agents;
        public void Init()
        {
            _quadTree = new QuadTree<IShape>();
            _quadTree.Init(6,new Rect(-4,-4,8,8));

            _agents = new Dictionary<int,IShape>();
            
        }

        public void Add(int ent,IShape agent)
        {
            _agents.Add(ent,agent);
            _quadTree.Insert(agent);
        }

        public void Remove(int ent,IShape agent)
        {
            _agents.Remove(ent);
            agent.RemoveTag = true;
        }
        
        public void Step(float deltaTime)
        {
            foreach (var agent in _agents.Values)
            {
                agent.Position += new float2(0.01f*Random.Range(-1, 1), 0);
            }
            _quadTree.Update();
        }
        
        
    }
    
    [Flags]
    public enum CollisionLayer {
        Default = 1 << 0,
        Player =  1 << 1,
        Enemy = 1 << 2,
        Projectile = 1 << 3,
    }
    
    
    //初筛
    //两两检测
    public partial class PhysicsWorld
    {
        /// <summary>
        /// 检测指定层是否包含在CollideWith中
        /// </summary>
        /// <param name="targetLayer"></param>
        /// <param name="collideWith"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsCollideWithLayer(CollisionLayer collideWith,CollisionLayer targetLayer)
        {
            int mask = (int)collideWith & (int)targetLayer;
            return mask == (int)targetLayer;
        }
        
        public static void CheckCollision(CircleCollider a,CircleCollider b)
        {
            //a和b是否碰撞
            if (IsCollideWithLayer(b.layer,a.collideWith))
            {
                
            }
            //b和a是否碰撞
            if (IsCollideWithLayer(a.layer,b.collideWith))
            {
                
            }
        }

        public static void CheckCollision(BoxCollider a,BoxCollider b)
        {
            //a和b是否碰撞
            if (IsCollideWithLayer(b.layer,a.collideWith))
            {
                
            }
            //b和a是否碰撞
            if (IsCollideWithLayer(a.layer,b.collideWith))
            {
                
            }
        }

        public static void CheckCollision(BoxCollider a, CircleCollider b)
        {
            //a和b是否碰撞
            if (IsCollideWithLayer(b.layer,a.collideWith))
            {
                
            }
            //b和a是否碰撞
            if (IsCollideWithLayer(a.layer,b.collideWith))
            {
                
            }
        }
        
        
        /// <summary>
        /// 线段检测
        /// </summary>
        public static void LineCast(){}
        /// <summary>
        /// 返回边界与collider.bounds相交的所有碰撞器
        /// </summary>
        public static void BoxCastBroadPhase(){}
        /// <summary>
        /// 矩形区域检测
        /// </summary>
        public static void OverlapRectangle(){}
        /// <summary>
        /// 圆形区域检测
        /// </summary>
        public static void OverlapCircle(){}
        
        
    }
    
    
}