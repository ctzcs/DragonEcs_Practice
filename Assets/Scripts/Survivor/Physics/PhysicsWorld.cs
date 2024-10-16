using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;


namespace Survivor.Physics
{
    public partial class PhysicsWorld
    {
        public void Step(float deltaTime){}
        
        
    }
    public struct Bounds
    {
        public float width;
        public float height;
        public float xMin;
        public float yMin;
        public static Bounds None = new Bounds(0,0,0, 0);
        public Bounds(float xMin,float yMin,float width, float height)
        {
            this.xMin = xMin;
            this.yMin = yMin;
            this.width = width;
            this.height = height;
        }
        
        public bool Contains(float2 pos)
        {
            return pos.x >= xMin && pos.x <= xMin + width
                                 && pos.y >= yMin && pos.y <= yMin + height;
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

    public interface IShape
    {
        Bounds Bounds { get; }
        float2 Position { get; }
    }
    /// <summary>
    /// T为存档的对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QuadTree<T> where T:IShape
    {
        private Bounds _bounds;
        private Node _root;
        private NodePool<Node> _nodePool;
        public byte MaxDepth = 6;
        public byte SplitThreshold = 4;
        
        //初始化根节点
        public void Init(byte maxLayer,Bounds bounds)
        {
            MaxDepth = maxLayer;
            _bounds = bounds;
            _root = _nodePool.PopNode();
            _root.Init(0,this,_bounds);
            _nodePool = new NodePool<Node>(()=>new Node());
        }
        //获取节点
        public Node CreateNode() => _nodePool.PopNode();

        public void ReleaseNode(Node node) => _nodePool.PushNode(node);
        //插入节点
        public void Insert(T data)
        {
            if (_root.Bounds.Contains(data.Position))
            {
                _root.Insert(data,MaxDepth,SplitThreshold);
            }
        }

        
        //更新
        public void Update(){}
        public class Node:INodePool
        {
            public QuadTree<T> belongTree;

            public byte Depth;
            //边界
            public Bounds Bounds;
            //松散边界
            public Bounds LooseBounds;
            public Node father;
            public Node lb, rb, lt, rt;
            public List<T> dataList = new();
            public bool IsLeaf=> lb == null;
            public void Init(byte depth,QuadTree<T> belongTree,Bounds bounds)
            {
                this.Depth = depth;
                this.belongTree = belongTree;
                this.Bounds = bounds;
                LooseBounds = new Bounds(bounds.xMin - bounds.width * 0.5f,bounds.yMin - bounds.height * 0.5f,bounds.width*2,bounds.height*2);
                
            }

            void INodePool.OnSpawn()
            {
                
            }
            void INodePool.OnRelease()
            {
                Depth = 0;
                belongTree = null;
                Bounds = Bounds.None;
                LooseBounds = Bounds.None;
            }

            public void Insert(T e, byte maxDepth, byte splitThreshold)
            {
                float2 pos = e.Position;
                //插入节点，如果数量大于分裂标准，则产生子节点
                Node node = this;
                do
                {
                    if (node.IsLeaf)
                    {
                        //插入时，节点中的数据到达分裂阈值,分裂并放入子节点
                        if (node.Depth < maxDepth
                            && node.dataList.Count >= splitThreshold)
                        {
                            node.SplitOrInsert(e);
                        }
                        else
                        {
                            //未达到，直接加入
                            node.dataList.Add(e);
                        }
                        return;
                    }
                    //如果不是叶子节点，找到合适的子节点
                    node = node.FindBestChild(pos);
                    
                } while (true);
            }
            /// <summary>
            /// 合并子节点数据
            /// </summary>
            public void Merge()
            {
                //将子节点的item添加到这个结点中，子节点push到结点池
                dataList.Clear();
                foreach (var data in lb.dataList)
                {
                    dataList.Add(data);
                }
                foreach (var data in rb.dataList)
                {
                    dataList.Add(data);
                }
                foreach (var data in lt.dataList)
                {
                    dataList.Add(data);
                }
                foreach (var data in rt.dataList)
                {
                    dataList.Add(data);
                }

                belongTree.ReleaseNode(lb);
                lb = null;
                belongTree.ReleaseNode(rb);
                rb = null;
                belongTree.ReleaseNode(lt);
                lt = null;
                belongTree.ReleaseNode(rt);
                rt = null;
            }

            /// <summary>
            /// 分裂并插入数据
            /// </summary>
            /// <param name="e"></param>
            private void SplitOrInsert(T e)
            {
                //产生下一个深度的节点
                byte depth = (byte)(Depth + 1);
                float subWidth = Bounds.width * 0.5f;
                float subHeight = Bounds.height * 0.5f;
                //产生子节点
                lb = belongTree.CreateNode();
                lb.Init(depth,belongTree,new Bounds(Bounds.xMin,Bounds.yMin,subWidth,subHeight));
                rb = belongTree.CreateNode();
                rb.Init(depth,belongTree,new Bounds(Bounds.xMin + subWidth,Bounds.yMin,subWidth,subHeight));
                lt = belongTree.CreateNode();
                lt.Init(depth,belongTree,new Bounds(Bounds.xMin,Bounds.yMin + subHeight,subWidth,subHeight));
                rt = belongTree.CreateNode();
                rt.Init(depth,belongTree,new Bounds(Bounds.xMin + subWidth,Bounds.yMin + subHeight,subWidth,subHeight));
                //将父节点所有元素放入子节点
                foreach (var data in dataList)
                {
                    FindBestChild(data.Position).dataList.Add(data);//.Insert(data, belongTree.MaxDepth, belongTree.SplitThreshold);
                }
                //将该节点放入子节点
                FindBestChild(e.Position).dataList.Add(e);//.Insert(e,belongTree.MaxDepth,belongTree.SplitThreshold);
                //清空父节点中的数据
                dataList.Clear();
            }

            /// <summary>
            /// 放入最合适的子节点中
            /// </summary>
            /// <param name="pos"></param>
            /// <returns></returns>
            private Node FindBestChild(float2 pos)
            {
                int index = ((pos.x > Bounds.xMin + Bounds.width * 0.5f ? 1 : 0) +
                             (pos.y > Bounds.yMin + Bounds.height * 0.5f ? 2 : 0));
                return (index) switch
                {
                    0=>lb,
                    1=>rb,
                    2=>lt,
                    3=>rt,
                    _ => null
                };
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