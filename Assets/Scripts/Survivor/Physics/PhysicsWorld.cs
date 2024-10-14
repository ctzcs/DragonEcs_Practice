using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DCFApixels.DragonECS;


namespace Survivor.Physics
{
    public partial class PhysicsWorld
    {
        public QuadTree<entlong> tree;
        public void Step(){}
        
        
        
    }
    public struct Bounds
    {
        public float halfWidth;
        public float halfHeight;
    }
    
    [Flags]
    public enum CollisionLayer {
        None = 0,
        Player =  1 << 0,
        Enemy = 1 << 1,
        Projectile = 1 << 2,
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
    
    
    #region 优化结构

    /// <summary>
    /// T为存档的对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QuadTree<T>
    {
        //初始化根节点
        //获取节点
        //插入节点
        //更新
    }

    public class QuadTreeNode<T>
    {
        public int layer;
        public QuadTree<T> belongTree;
        public Bounds bounds;
        public QuadTreeNode<T> father;
        public List<T> nodeDataList;
    }
    
    
    
    #endregion
    
}