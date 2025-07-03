using System;
using System.Diagnostics;
using System.Text;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace Framework
{
    /// <summary>
    /// 简单的Debug封装
    /// </summary>
    public static class MyLog
    {
        private static Logger logger;
        private static readonly StringBuilder s_StringBuilder = new();
        private static GameObject unityDebug;
        
        public static void Init(Action initConfig)
        {
            if (unityDebug == null)
            {
                unityDebug = new GameObject("[UnityDebug]");
                unityDebug.AddComponent<UnityDebugAppender>();
                //unityDebug.AddComponent<WindowsConsole>();
                Object.DontDestroyOnLoad(unityDebug);
            }

            if (logger != null) return;
            logger = Logger.GetLogger("MyLog");
            initConfig?.Invoke();

        }
        
        

        [Conditional("ENABLE_DEBUG_LOG")]
        public static void Log(params object[] message)
        {
            s_StringBuilder.Clear();
            s_StringBuilder.Append($"[Log][{Time.realtimeSinceStartup}]");
            for (var i = 0; i < message.Length; i++) s_StringBuilder.Append(message[i]);

#if UNITY_EDITOR || PLATFORM_ANDROID
            Debug.Log(s_StringBuilder);
#else
            logger.Info(s_StringBuilder.ToString());
#endif
        }

        public static void Warning(params object[] message)
        {
            s_StringBuilder.Clear();
            s_StringBuilder.Append($"[Warning][{Time.realtimeSinceStartup}]");
            for (var i = 0; i < message.Length; i++) s_StringBuilder.Append(message[i]);
#if UNITY_EDITOR || PLATFORM_ANDROID
            Debug.LogWarning(s_StringBuilder);
#else
            logger.Warn(s_StringBuilder.ToString());
#endif
        }

        public static void Error(params object[] message)
        {
            s_StringBuilder.Clear();
            s_StringBuilder.Append($"[Error][{Time.realtimeSinceStartup}]");
            for (var i = 0; i < message.Length; i++) s_StringBuilder.Append(message[i]);

#if UNITY_EDITOR || PLATFORM_ANDROID
            Debug.LogError(s_StringBuilder);
#else
            logger.Error(s_StringBuilder.ToString());
#endif
        }

        public static void LogException(Exception message)
        {
            Debug.LogException(message);
        }
    }
}