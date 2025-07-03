using System;
using System.Collections.Generic;

namespace Framework
{
    public class ReferenceCollector
    {
        private Stack<IReference> m_Collector;
        public Type ClassType { private set; get; }
        
        /// <summary>
        /// 内部缓存总量
        /// </summary>
        public int Count
        {
            get { return m_Collector.Count; }
        }
        /// <summary>
        /// 使用量
        /// </summary>
        public int SpawnCount { private set; get; }

        public ReferenceCollector(Type type, int capacity)
        {
            ClassType = type;
            m_Collector = new Stack<IReference>(capacity);
            Type temp = type.GetInterface(nameof(IReference));
            if (temp == null)
                throw new Exception($"{type.Name} must inherit from {nameof(IReference)}");
        }
        
        /// <summary>
        /// 申请引用对象
        /// </summary>
        public IReference Spawn()
        {
            IReference item;
            if (m_Collector.Count > 0)
            {
                item = m_Collector.Pop();
            }
            else
            {
                item = Activator.CreateInstance(ClassType) as IReference;
            }

            SpawnCount++;
            item?.OnSpawn();
            return item;
        }

        /// <summary>
        /// 回收引用对象
        /// </summary>
        public void Release(IReference item)
        {
            if (item == null)
                return;

            if (item.GetType() != ClassType)
                throw new Exception($"Invalid type {item.GetType()}");

            if (m_Collector.Contains(item))
                throw new Exception($"The item {item.GetType()} already exists.");

            SpawnCount--;
            m_Collector.Push(item);
        }

        /// <summary>
        /// 清空集合
        /// </summary>
        public void Clear()
        {
            m_Collector.Clear();
            SpawnCount = 0;
        }
    }
}