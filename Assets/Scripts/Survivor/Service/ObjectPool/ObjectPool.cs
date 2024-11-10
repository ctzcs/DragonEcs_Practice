using System;
using System.Collections.Generic;

namespace Survivor.Service
{
    public class ObjectPool<TK> where TK:IPooled
    {
        private Stack<TK> _nodes = new();
        private Func<TK> _createFunc;

        public ObjectPool(Func<TK> createNodeFunc)
        {
            _createFunc = createNodeFunc;
        }

        public void Push(TK node)
        {
            _nodes.Push(node);
            node.OnRelease();
        }

        public TK Pop()
        {
            TK node = _nodes.Count > 0 ? _nodes.Pop() : _createFunc.Invoke();
            node.OnSpawn();
            return node;
        }
    }
    
    public interface IPooled
    {
        void OnSpawn();
        void OnRelease();
    }
    
}