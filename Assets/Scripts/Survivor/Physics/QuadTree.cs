using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using Utility;

namespace Survivor.Physics
{
    public struct Bounds
    {
        public float width;
        public float height;
        public float xMin;
        public float yMin;
        public Vector2 Center
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(this.xMin + this.width / 2f, this.yMin + this.height / 2f);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set
            {
                xMin = value.x - width / 2f;
                yMin = value.y - height / 2f;
            }
        }
        
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

    
    public interface IShape
    {
        bool RemoveTag { get; set; }
        Rect Bounds { get; set; }
        float2 Position { get; set; }
        public CollisionLayer Layer { get; }
        public CollisionLayer CollideWith { get; }
    }
    /// <summary>
    /// T为存档的对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QuadTree<T> where T: class, IShape
    {
        //根节点
        private Node _root;
        /// <summary>
        /// 结点池
        /// </summary>
        private NodePool<Node> _nodePool;
        /// <summary>
        /// 处理栈
        /// </summary>
        private Stack<Node> _tempProcessStack;
        /// <summary>
        /// 插入栈
        /// </summary>
        private Stack<T> _tempRemoveAndInsertStack;
        /// <summary>
        /// 移除栈
        /// </summary>
        private Stack<T> _tempRemoveStack;
        /// <summary>
        /// 合并集
        /// </summary>
        private HashSet<Node> _mergeSet;

        private List<T> _queryList;
        private Stack<Node> _queryNodeStack;
        
        /// <summary>
        /// 最大深度
        /// </summary>
        public byte MaxDepth = 6;
        /// <summary>
        /// 分裂阈值
        /// </summary>
        public byte SplitThreshold = 4;
        /// <summary>
        /// 合并阈值
        /// </summary>
        public byte MergeThreshold = 2;

        private Action<T> _updateDataCallback;
        
        //初始化根节点
        public void Init(byte maxLayer,Rect bounds)
        {
            MaxDepth = maxLayer;
            _nodePool = new NodePool<Node>(() => new Node());
            _tempProcessStack = new Stack<Node>();
            _tempRemoveAndInsertStack = new Stack<T>();
            _tempRemoveStack = new Stack<T>();
            _mergeSet = new HashSet<Node>();
            _queryList = new List<T>();
            _queryNodeStack = new Stack<Node>();
            _root = _nodePool.PopNode();
            _root.Init(0,this,bounds);
            
            
        }

        public List<T> QueryBounds(Rect range)
        {
            if (_queryList.Count > 0)
            {
                _queryList.Clear();
            }

            if (_root.Bounds.Overlaps(range))
            {
                _queryNodeStack.Push(_root);
                do
                {
                    var cur = _queryNodeStack.Pop();
                    // 如果是叶子节点 就拿数据
                    if (cur.IsLeaf)
                    {
                        foreach (var data in cur.dataList)
                        {
                            if (range.Overlaps(data.Bounds))
                            {
                                _queryList.Add(data);
                            }
                        }
                    }
                    else cur.PushBoundsChild(range);
                }
                while (_queryNodeStack.Count > 0);
            }

            return _queryList;
        }
        
        //插入节点
        public void Insert(T data)
        {
            if (_root.Bounds.Contains(data.Position))
            {
                _root.Insert(data,MaxDepth,SplitThreshold);
            }
        }

        
        //更新
        public void Update()
        {
            //遍历节点树
            //处理所有叶子节点
            //如果有元素移除Tag,推到移除缓冲区
            //如果还在当前范围内，则更新当前元素
            //如果不在当前范围，在不在根节点范围，如果在推入重插缓冲区，如果不在说明离开碰撞区域，推到移除缓冲区
            //将移除缓冲区的元素移除
            //将重插缓冲区的元素从当前节点移除，并重插入
            //检查该叶子是否需要合并到父节点，如果需要放入合并集合
            //结束后合并
            _tempProcessStack.Push(_root);
            do
            {
                var curNode = _tempProcessStack.Pop();
                var curNodeCenter = curNode.Bounds.center;
                MonoHelp.DrawBox(curNode.Bounds.center,
                    new Vector2(curNode.Bounds.width,curNode.Bounds.height),Color.green);
                //TODO 绘制当前节点
                if (curNode.IsLeaf)
                {
                    //处理叶子节点上的数据
                    for (int i = 0; i < curNode.dataList.Count; i++)
                    {
                        var data = curNode.dataList[i];
                        float2 pos = data.Position;
                        
                        MonoHelp.DrawBox(data.Bounds.center,
                            new Vector2(data.Bounds.width,data.Bounds.height),Color.green);
                        //如果标签移除，则将其放入移除缓冲
                        if (data.RemoveTag)
                        {
                            _tempRemoveStack.Push(data);
                            data.RemoveTag = false;
                            continue;
                        }
                        //还在当前节点范围，更新数据，
                        //如果不在，判断还在不在根节点中，放入插入栈，如果不在，说明离开树，放入移除区域
                        if (curNode.Bounds.Contains(pos))
                        {
                            _updateDataCallback?.Invoke(data);
                        }
                        else
                        {
                            if (_root.Bounds.Contains(pos))
                            {
                                _tempRemoveAndInsertStack.Push(data);
                            }
                            else
                            {
                                _tempRemoveStack.Push(data);
                            }
                        }
                    }
                    

                    while (_tempRemoveStack.Count > 0)
                    {
                        curNode.dataList.Remove(_tempRemoveStack.Pop());
                    }

                    while (_tempRemoveAndInsertStack.Count>0)
                    {
                        T data = _tempRemoveAndInsertStack.Pop();
                        curNode.dataList.Remove(data);
                        _root.Insert(data,MaxDepth,SplitThreshold);
                        _updateDataCallback?.Invoke(data);
                    }

                    var father = curNode.father;
                    if (father == null || father.IsLeaf) continue;
                    if (father.GetChildrenSum() <= MergeThreshold)
                    {
                        //重复的不会被加进去，有没有可能之前加入了合并集，后面又多了几个元素呢？
                        _mergeSet.Add(father);
                    }
                }
                else
                {
                    curNode.ProcessChild();
                }
            } while (_tempProcessStack.Count > 0);

            if (_mergeSet.Count <= 0) return;
            foreach (var node in _mergeSet)
            {
                node.Merge();
            }
            _mergeSet.Clear();

        }
        
        //获取节点
        private Node CreateNode() => _nodePool.PopNode();

        private void ReleaseNode(Node node) => _nodePool.PushNode(node);
        
        public class Node:INodePool
        {
            public QuadTree<T> belongTree;

            public byte Depth;
            //边界
            public Rect Bounds;
            //松散边界
            public Rect LooseBounds;
            public Node father;
            public Node lb, rb, lt, rt;
            public List<T> dataList = new();
            public bool IsLeaf=> lb == null;
            public void Init(byte depth,QuadTree<T> belongTree,Rect bounds)
            {
                this.Depth = depth;
                this.belongTree = belongTree;
                this.Bounds = bounds;
                LooseBounds = new Rect(bounds.x,bounds.y,bounds.width*2,bounds.height*2);
                
            }

            void INodePool.OnSpawn()
            {
                
            }
            void INodePool.OnRelease()
            {
                Depth = 0;
                belongTree = null;
                Bounds = Rect.zero;
                LooseBounds = Rect.zero;
            }

            /// <summary>
            /// 插入元素
            /// </summary>
            /// <param name="e"></param>
            /// <param name="maxDepth"></param>
            /// <param name="splitThreshold"></param>
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
                    //如果不是叶子节点，找到合适的子节点，每次找到的都是孩子
                    node = node.FindBestChild(pos);
                    
                } while (true);
            }
            /// <summary>
            /// 合并子节点数据
            /// </summary>
            public void Merge()
            {
                if (GetChildrenSum() > belongTree.MergeThreshold)
                {
                    return;
                }
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

            public void ProcessChild()
            {
                var tempProcessStack = belongTree._tempProcessStack;
                tempProcessStack.Push(lb);
                tempProcessStack.Push(rb);
                tempProcessStack.Push(lt);
                tempProcessStack.Push(rt);
            }

            public void PushBoundsChild(Rect range)
            {
                var queryNodeStack = belongTree._queryNodeStack;
                if (lb.Bounds.Overlaps(range)) queryNodeStack.Push(lb);
                if (rb.Bounds.Overlaps(range)) queryNodeStack.Push(rb);
                if (lt.Bounds.Overlaps(range)) queryNodeStack.Push(lt);
                if (rt.Bounds.Overlaps(range)) queryNodeStack.Push(rt);
                Rect c;
                
            }
            
            public int GetChildrenSum()
            {
                return lb.dataList.Count + rb.dataList.Count + lt.dataList.Count + rt.dataList.Count;
            }
            
            /// <summary>
            /// 分裂并插入数据（直接将值放到子节点中，而不是调用插入，成本最低）
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
                lb.Init(depth,belongTree,new Rect(Bounds.x,Bounds.y,subWidth,subHeight));
                rb = belongTree.CreateNode();
                rb.Init(depth,belongTree,new Rect(Bounds.x + subWidth,Bounds.y,subWidth,subHeight));
                lt = belongTree.CreateNode();
                lt.Init(depth,belongTree,new Rect(Bounds.x,Bounds.y + subHeight,subWidth,subHeight));
                rt = belongTree.CreateNode();
                rt.Init(depth,belongTree,new Rect(Bounds.x + subWidth,Bounds.y + subHeight,subWidth,subHeight));
                //将父节点所有元素放入子节点
                foreach (var data in dataList)
                {
                    FindBestChild(data.Position).dataList.Add(data);//.Insert(data, belongTree.MaxDepth, belongTree.SplitThreshold);
                }
                //将该节点放入子节点
                FindBestChild(e.Position).dataList.Add(e);//.Insert(e,belongTree.MaxDepth,belongTree.SplitThreshold);
                //清空父节点中的数据 TODO 为什么不能清空呢？
                //dataList.Clear();
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

}