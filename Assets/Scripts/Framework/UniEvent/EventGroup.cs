using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    /// <summary>
    /// 一个事件类型对应一系列listener
    /// </summary>
    public class EventGroup
    {
        private readonly Dictionary<System.Type, List<System.Action<IEventMessage>>> m_CachedListener = new Dictionary<System.Type, List<System.Action<IEventMessage>>>();

        /// <summary>
        /// 添加一个监听
        /// </summary>
        public void AddListener<TEvent>(System.Action<IEventMessage> listener) where TEvent : IEventMessage
        {
            System.Type eventType = typeof(TEvent);
            if (m_CachedListener.ContainsKey(eventType) == false)
                m_CachedListener.Add(eventType, new List<System.Action<IEventMessage>>());

            if (m_CachedListener[eventType].Contains(listener) == false)
            {
                //在缓存中添加
                m_CachedListener[eventType].Add(listener);
                //在事件中心添加
                UniEvent.AddListener(eventType, listener);
            }
            else
            {
                Debug.LogWarning($"Event listener is exist : {eventType}");
            }
        }

        /// <summary>
        /// 移除所有缓存的监听
        /// </summary>
        public void RemoveAllListener()
        {
            foreach (var pair in m_CachedListener)
            {
                System.Type eventType = pair.Key;
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    UniEvent.RemoveListener(eventType, pair.Value[i]);
                }
                pair.Value.Clear();
            }
            m_CachedListener.Clear();
        }
    }
}
