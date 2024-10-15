using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DCFApixels.DragonECS;


namespace Survivor.Physics
{
    public partial class PhysicsWorld
    {
        public QuadTree<entlong> tree;
        public void Step(float deltaTime){}
        
        
    }
    public struct Bounds
    {
        public float halfWidth;
        public float halfHeight;

        public Bounds(float halfWidth, float halfHeight)
        {
            this.halfWidth = halfWidth;
            this.halfHeight = halfHeight;
        }
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
        private int _maxLayer;
        private Bounds _bounds;
        private Node _root;
        private NodePool<Node> _nodePool;
        
        //初始化根节点
        public void Init(int maxLayer,Bounds bounds)
        {
            _maxLayer = maxLayer;
            _bounds = bounds;
            _root = _nodePool.PopNode();
            _root.Init(0,this,_bounds);
            _nodePool = new NodePool<Node>(()=>new Node());
        }
        //获取节点
        public void GetNode(){}
        //插入节点
        public void Insert(T data)
        {
            
        }

        
        //更新
        public void Update(){}
        public class Node:INodePool
        {
            public QuadTree<T> belongTree;

            public int layer;
            //边界
            public Bounds bounds;
            //松散边界
            public Bounds looseBounds;
            public Node father;
            public List<Node> childList = new List<Node>(4);
            public List<T> nodeDataList = new();

            public void Init(int layer,QuadTree<T> belongTree,Bounds bounds)
            {
                this.layer = layer;
                this.belongTree = belongTree;
                this.bounds = bounds;
                looseBounds = new Bounds(bounds.halfWidth *2,bounds.halfHeight*2);
                
            }

            void INodePool.OnSpawn()
            {
                
            }
            void INodePool.OnRelease()
            {
            
            }
        
            public void Insert(T e,int maxLayer,int splitThreshold){}
            public void Merge()
            {
                //将子节点的item添加到这个结点中，子节点push到结点池
            
            }
        }

        public class NodePool<TK> where TK:INodePool
        {
            private Stack<TK> _nodes = new();
            private Func<TK> _createFunc;

            public NodePool(Func<TK> createNodeFunc)
            {
                _createFunc = createNodeFunc;
            }

            public void PushNode(TK node)
            {
                _nodes.Push(node);
                node.OnRelease();
            }

            public TK PopNode()
            {
                TK node = _nodes.Count > 0 ? _nodes.Pop() : _createFunc.Invoke();
                node.OnSpawn();
                return node;
            }
        }
        
        public interface INodePool
        {
            void OnSpawn();
            void OnRelease();
        }
    }

    
    
    
    #endregion
    
}