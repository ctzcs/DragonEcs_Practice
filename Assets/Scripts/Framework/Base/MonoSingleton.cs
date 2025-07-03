using UnityEngine;

namespace Framework
{
    [DisallowMultipleComponent]
    public class MonoSingleton<T>:MonoBehaviour where T:MonoBehaviour
    {
        private static T m_Instance;
        
        public static T Instance => m_Instance;

        protected virtual void Awake()
        {
            if (m_Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            m_Instance = this as T;
        }
        
    }
}