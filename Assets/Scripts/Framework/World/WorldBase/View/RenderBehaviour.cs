using Sirenix.OdinInspector;
using UnityEngine;

namespace Framework
{
    /// <summary>
    /// 游戏中所有Mono层的实体都继承自Entity
    /// </summary>
    public abstract class RenderBehaviour : MonoBehaviour
    {
        [ShowInInspector]
        private string m_Name = "Untitled Entity";
        private GameObject m_CacheGameObject;
        private Transform m_CacheTransform;
        
        public string Name { get => m_Name; set { m_Name = value; if (CacheGameObject is not null) CacheGameObject.name = Name; } }
        public GameObject CacheGameObject => m_CacheGameObject;
        public Transform CacheTransform => m_CacheTransform;

        #region Unity生命周期
        protected virtual void Awake()
        {
            m_CacheGameObject = gameObject;
            m_CacheTransform = m_CacheGameObject.transform;
        }

        protected virtual void OnDestroy()
        {
            m_CacheGameObject = null;
            m_CacheTransform = null;
        }
        #endregion
        
    }
}