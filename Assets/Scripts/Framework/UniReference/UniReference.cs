using System;
using System.Collections.Generic;

namespace Framework
{
    /// <summary>
    /// 引用池
    /// </summary>
    public static class UniReference
    {
         private static readonly Dictionary<Type, ReferenceCollector> m_Collectors = new Dictionary<Type, ReferenceCollector>();

        /// <summary>
        /// 对象池初始容量
        /// </summary>
        public static int InitCapacity { get; set; } = 100;

        /// <summary>
        /// 对象池的数量
        /// </summary>
        public static int Count
        {
            get
            {
                return m_Collectors.Count;
            }
        }


        /// <summary>
        /// 清除所有对象池
        /// </summary>
        public static void ClearAll()
        {
            m_Collectors.Clear();
        }

        /// <summary>
        /// 申请引用对象
        /// </summary>
        public static IReference Spawn(Type type)
        {
            if (m_Collectors.ContainsKey(type) == false)
            {
                m_Collectors.Add(type, new ReferenceCollector(type, InitCapacity));
            }
            return m_Collectors[type].Spawn();
        }

        /// <summary>
        /// 申请引用对象
        /// </summary>
        public static T Spawn<T>() where T : class, IReference, new()
        {
            Type type = typeof(T);
            return Spawn(type) as T;
        }

        /// <summary>
        /// 回收引用对象
        /// </summary>
        public static void Release(IReference item)
        {
            Type type = item.GetType();
            if (m_Collectors.ContainsKey(type) == false)
            {
                m_Collectors.Add(type, new ReferenceCollector(type, InitCapacity));
            }
            m_Collectors[type].Release(item);
        }

        /// <summary>
        /// 批量回收列表集合
        /// </summary>
        public static void Release<T>(List<T> items) where T : class, IReference, new()
        {
            Type type = typeof(T);
            if (m_Collectors.ContainsKey(type) == false)
            {
                m_Collectors.Add(type, new ReferenceCollector(type, InitCapacity));
            }

            for (int i = 0; i < items.Count; i++)
            {
                m_Collectors[type].Release(items[i]);
            }
        }

        /// <summary>
        /// 批量回收数组集合
        /// </summary>
        public static void Release<T>(T[] items) where T : class, IReference, new()
        {
            Type type = typeof(T);
            if (m_Collectors.ContainsKey(type) == false)
            {
                m_Collectors.Add(type, new ReferenceCollector(type, InitCapacity));
            }

            for (int i = 0; i < items.Length; i++)
            {
                m_Collectors[type].Release(items[i]);
            }
        }

        #region 调试专属方法
        internal static Dictionary<Type, ReferenceCollector> GetAllCollectors
        {
            get { return m_Collectors; }
        }
        #endregion
    }
}
