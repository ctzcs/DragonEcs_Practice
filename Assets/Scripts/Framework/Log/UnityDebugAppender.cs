using System;
using UnityEngine;

namespace Framework
{
    public class UnityDebugAppender : MonoBehaviour
    {
        // private GameObject obj;
        private void Awake()
        {
            Application.logMessageReceived += OnLogMessageReceived;
        }

        private void OnDisable()
        {
            Application.logMessageReceived -= OnLogMessageReceived;
        }


        // private void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.Y))
        //     {
        //         MyLog.Log(obj.transform);
        //     }
        // }

        private void OnLogMessageReceived(string msg, string stackTrace, LogType type)
        {
#if !UNITY_EDITOR
        switch (type)
        {
            case LogType.Log:
                MyLog.Log(msg,stackTrace);
                break;
            case LogType.Warning:
                MyLog.Warning(msg,stackTrace);
                break;
            case LogType.Error:
                MyLog.Error(msg,stackTrace);
                break;
            case LogType.Exception:
                MyLog.Error(msg,stackTrace);
                break;
            default:
                MyLog.Log(msg,stackTrace);
                break;
        }
#endif
        }
    }
}