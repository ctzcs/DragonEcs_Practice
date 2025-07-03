using System;

namespace Framework
{
    public partial class World
    {
        public void AddDataMgr(IDataMgrBehaviour dataMgrBehaviour)
        {
            s_DataBehaviourDic.Add(dataMgrBehaviour.GetType().Name,dataMgrBehaviour);
            dataMgrBehaviour.OnCreate();
        }

        public void AddMsgMgr(IMsgMgrBehaviour msgMgrBehaviour)
        {
            s_MsgBehaviourDic.Add(msgMgrBehaviour.GetType().Name,msgMgrBehaviour);
            msgMgrBehaviour.OnCreate();
        }
        public void AddLogicCtrl(ILogicCtrlBehaviour logicCtrlBehaviour)
        {
            s_LogicBehaviourDic.Add(logicCtrlBehaviour.GetType().Name,logicCtrlBehaviour);
            logicCtrlBehaviour.OnCreate();
        }

        /// <summary>
        /// 替换注册的数据管理器
        /// </summary>
        /// <param name="dataMgrBehaviour"></param>
        public void ReplaceDataMgr(IDataMgrBehaviour dataMgrBehaviour)
        {
            if (dataMgrBehaviour is null)
            {
                MyLog.Warning(dataMgrBehaviour);
            }
            var key = dataMgrBehaviour.GetType().Name;
            if (!s_DataBehaviourDic.TryAdd(key,dataMgrBehaviour))
            {
                s_DataBehaviourDic[key].OnDestroy();
                s_DataBehaviourDic[key] = dataMgrBehaviour;
            }
            dataMgrBehaviour.OnLoad(dataMgrBehaviour);
            
        }

        /// <summary>
        /// 替换注册的消息管理器
        /// </summary>
        /// <param name="msgMgrBehaviour"></param>
        public void ReplaceMsgMgr(IMsgMgrBehaviour msgMgrBehaviour)
        {
            var key = msgMgrBehaviour.GetType().Name;
            if (!s_MsgBehaviourDic.TryAdd(key,msgMgrBehaviour))
            {
                s_MsgBehaviourDic[key].OnDestroy();
                s_MsgBehaviourDic[key] = msgMgrBehaviour;
            }
            msgMgrBehaviour.OnLoad(msgMgrBehaviour);
        }
        
        /// <summary>
        /// 替换注册的逻辑控制器
        /// </summary>
        /// <param name="logicCtrlBehaviour"></param>
        public void ReplaceLogicCtrl(ILogicCtrlBehaviour logicCtrlBehaviour)
        {
            var key = logicCtrlBehaviour.GetType().Name;
            if (!s_LogicBehaviourDic.TryAdd(key,logicCtrlBehaviour))
            {
                s_LogicBehaviourDic[key].OnDestroy();
                s_LogicBehaviourDic[key] = logicCtrlBehaviour;
                
            }
            logicCtrlBehaviour.OnLoad(logicCtrlBehaviour);
        }

        
    }
}