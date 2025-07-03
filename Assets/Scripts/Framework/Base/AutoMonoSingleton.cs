using UnityEngine;

namespace Framework
{
    [DisallowMultipleComponent]
    public class AutoMonoSingleton<T>:MonoBehaviour where T:MonoBehaviour
    {
        private static T m_Instance;
        /*/// <summary>
        /// 切场景的时候是否应该不销毁
        /// </summary>
        [ShowInInspector] [OnValueChanged("_DonDestroyOnLoadStateChange")]
        private bool m_DontDestroyOnLoadState;*/
        
        public static T Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    GameObject obj = new GameObject
                    {
                        name = typeof(T).Name
                    };
                    DontDestroyOnLoad(obj);
                    m_Instance = obj.AddComponent<T>();
                }
                
                return m_Instance;
            }
        }
        /*public bool DontDestroyOnLoadState {
            get => m_DontDestroyOnLoadState;
            set
            {
                m_DontDestroyOnLoadState = value;
                if (m_DontDestroyOnLoadState)
                {
                    DontDestroyOnLoad(this);
                }
                else
                {
                    SceneManager.MoveGameObjectToScene(gameObject,SceneManager.GetActiveScene());
                }
            }
        }*/
        

        /*
        #region Editor
#if UNITY_EDITOR
        /// <summary>
        /// 编辑器模式下设置是否切换场景不消除
        /// </summary>
        private void _DonDestroyOnLoadStateChange()
        {
            DontDestroyOnLoadState = m_DontDestroyOnLoadState;
        }
#endif
        

        #endregion*/


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