using System;
using System.Reflection;


namespace Framework
{
    /// <summary>
    /// 普通的单例模式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> where T:class
    {
        private static T m_Instance;
       
        public static T Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    ConstructorInfo info = typeof(T).GetConstructor(BindingFlags.Instance|BindingFlags.NonPublic,
                                                                    null,Type.EmptyTypes,null);
                    if (info is not null)
                    {
                        m_Instance = info.Invoke(null) as T;
                    }else
                        MyLog.Error($"{typeof(T).Name}没有得到无参构造函数,尝试添加一个私有的无参构造函数");
                    
                }
                return m_Instance;
            }
        }
        
    }
}