using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Framework
{
    public static class UniEvent
    {
        /// <summary>
        /// 延迟装饰器
        /// </summary>
        private class PostWrapper : IReference
        {
            public int PostFrame;
            public int EventID;
            public IEventMessage Message;
            
            public void OnSpawn()
            {
                PostFrame = 0;
                EventID = 0;
                Message = null;
            }
        }
        [ShowInInspector,ReadOnly]
        private static bool m_IsInitialize = false;
        private static UnityEngine.GameObject m_Driver = null;
        private static readonly Dictionary<int, LinkedList<System.Action<IEventMessage>>> m_Listeners = new (1000);
        private static readonly List<PostWrapper> m_PostingList = new List<PostWrapper>(1000);

        /// <summary>
        /// 初始化事件系统
        /// </summary>
        public static void Initialize()
        {
            if (m_IsInitialize)
            {
                MyLog.Log($"{nameof(UniEvent)} is initialized !");
                return;
            }

            if (m_IsInitialize == false)
            {
                // 创建驱动器
                m_IsInitialize = true;
                m_Driver = new UnityEngine.GameObject($"[{nameof(UniEvent)}]");
                m_Driver.AddComponent<UniEventDriver>();
                // UnityEngine.Object.DontDestroyOnLoad(m_Driver);
                Debug.Log($"{nameof(UniEvent)} initalize !");
            }
        }

        /// <summary>
        /// 销毁事件系统
        /// </summary>
        public static void Destroy()
        {
            if (m_IsInitialize)
            {
                ClearAll();

                m_IsInitialize = false;
                if (m_Driver != null)
                    UnityEngine.Object.Destroy(m_Driver);
                Debug.Log($"{nameof(UniEvent)} destroy all !");
            }
        }

        /// <summary>
        /// 更新事件系统
        /// 用来触发延迟帧的事件
        /// </summary>
        internal static void Update()
        {
            for (int i = m_PostingList.Count - 1; i >= 0; i--)
            {
                var wrapper = m_PostingList[i];
                if (UnityEngine.Time.frameCount > wrapper.PostFrame)
                {
                    SendMessage(wrapper.EventID, wrapper.Message);
                    m_PostingList.RemoveAt(i);
                    UniReference.Release(wrapper);
                }
            }
        }

        /// <summary>
        /// 清空所有监听
        /// </summary>
        public static void ClearAll()
        {
            foreach (int eventId in m_Listeners.Keys)
            {
                m_Listeners[eventId].Clear();
            }
            m_Listeners.Clear();
            m_PostingList.Clear();
        }

        /// <summary>
        /// 添加监听
        /// </summary>
        public static void AddListener<TEvent>(System.Action<IEventMessage> listener) where TEvent : IEventMessage
        {
            System.Type eventType = typeof(TEvent);
            int eventId = eventType.GetHashCode();
            AddListener(eventId, listener);
        }

        /// <summary>
        /// 添加监听
        /// </summary>
        public static void AddListener(System.Type eventType, System.Action<IEventMessage> listener)
        {
            int eventId = eventType.GetHashCode();
            AddListener(eventId, listener);
        }

        /// <summary>
        /// 添加监听
        /// </summary>
        public static void AddListener(int eventId, System.Action<IEventMessage> listener)
        {
            if (m_Listeners.ContainsKey(eventId) == false)
                m_Listeners.Add(eventId, new LinkedList<System.Action<IEventMessage>>());
            if (m_Listeners[eventId].Contains(listener) == false)
                m_Listeners[eventId].AddLast(listener);
        }


        /// <summary>
        /// 移除监听
        /// </summary>
        public static void RemoveListener<TEvent>(System.Action<IEventMessage> listener) where TEvent : IEventMessage
        {
            System.Type eventType = typeof(TEvent);
            int eventId = eventType.GetHashCode();
            RemoveListener(eventId, listener);
        }

        /// <summary>
        /// 移除监听
        /// </summary>
        public static void RemoveListener(System.Type eventType, System.Action<IEventMessage> listener)
        {
            int eventId = eventType.GetHashCode();
            RemoveListener(eventId, listener);
        }

        /// <summary>
        /// 移除监听
        /// </summary>
        public static void RemoveListener(int eventId, System.Action<IEventMessage> listener)
        {
            if (m_Listeners.ContainsKey(eventId))
            {
                if (m_Listeners[eventId].Contains(listener))
                    m_Listeners[eventId].Remove(listener);
            }
        }


        /// <summary>
        /// 实时广播事件
        /// </summary>
        public static void SendMessage(IEventMessage message)
        {
            int eventId = message.GetType().GetHashCode();
            SendMessage(eventId, message);
        }

        /// <summary>
        /// 实时广播事件
        /// </summary>
        public static void SendMessage(int eventId, IEventMessage message)
        {
            if (m_Listeners.ContainsKey(eventId) == false)
                return;

            LinkedList<System.Action<IEventMessage>> listeners = m_Listeners[eventId];
            if (listeners.Count > 0)
            {
                var currentNode = listeners.Last;
                while (currentNode != null)
                {
                    currentNode.Value.Invoke(message);
                    currentNode = currentNode.Previous;
                }
            }

            // 回收引用对象
            IReference refClass = message as IReference;
            if (refClass != null)
                UniReference.Release(refClass);
        }

        /// <summary>
        /// 延迟广播事件
        /// </summary>
        public static void PostMessage(IEventMessage message)
        {
            int eventId = message.GetType().GetHashCode();
            PostMessage(eventId, message);
        }

        /// <summary>
        /// 延迟广播事件
        /// </summary>
        public static void PostMessage(int eventId, IEventMessage message)
        {
            var wrapper = new PostWrapper();
            wrapper.PostFrame = UnityEngine.Time.frameCount;
            wrapper.EventID = eventId;
            wrapper.Message = message;
            m_PostingList.Add(wrapper);
        }
    }
}
