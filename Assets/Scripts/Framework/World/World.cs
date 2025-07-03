using System.Collections.Generic;

namespace Framework
{
    public partial class World:ILogicUpdate,ISerializable
    {
        /// <summary>
        /// 消息层
        /// </summary>
        private static Dictionary<string, IMsgMgrBehaviour> s_MsgBehaviourDic = new();
        /// <summary>
        /// 数据层
        /// </summary>
        private static Dictionary<string,IDataMgrBehaviour> s_DataBehaviourDic = new();
        /// <summary>
        /// 逻辑层
        /// </summary>
        private static Dictionary<string, ILogicCtrlBehaviour> s_LogicBehaviourDic = new();
        
        
        public virtual void OnSave() { }

        public virtual void OnLoad(object data) { }
        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void OnCreate() { }
        /// <summary>
        /// 更新
        /// </summary>
        public virtual void OnFixedUpdate(float fixedUpdateTime){}
        /// <summary>
        /// 销毁
        /// </summary>
        public virtual void OnDestroy(){}

        /// <summary>
        /// 销毁世界
        /// </summary>
        /// <param name="nameSpace"></param>
        /// <param name="pars"></param>
        public void DestroyWorld(string nameSpace, object pars = null)
        {
            List<string> removeTempList = new List<string>();
            foreach (var item in s_LogicBehaviourDic)
            {
                if (string.Equals(item.Value.GetType().Namespace,nameSpace))
                {
                    removeTempList.Add(item.Key);
                }
            }
            foreach (var key in removeTempList)
            {
                s_LogicBehaviourDic[key].OnDestroy();
                s_LogicBehaviourDic.Remove(key);
            }
            //清除数据层
            removeTempList.Clear();
            foreach (var item in s_DataBehaviourDic)
            {
                if (string.Equals(item.Value.GetType().Namespace,nameSpace))
                {
                    removeTempList.Add(item.Key);
                }
            }
            foreach (var key in removeTempList)
            {
                s_DataBehaviourDic[key].OnDestroy();
                s_DataBehaviourDic.Remove(key);
            }
            
            //清除消息层
            removeTempList.Clear();
            foreach (var item in s_MsgBehaviourDic)
            {
                if (string.Equals(item.Value.GetType().Namespace,nameSpace))
                {
                    removeTempList.Add(item.Key);
                }
            }
            foreach (var key in removeTempList)
            {
                s_MsgBehaviourDic[key].OnDestroy();
                s_MsgBehaviourDic.Remove(key);
            }
            OnDestroy();
            OnLateDestroy(pars);
        }
        /// <summary>
        /// 销毁后触发
        /// </summary>
        public virtual void OnLateDestroy(object args){}

        /// <summary>
        /// 获取逻辑控制器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetLogicCtrl<T>() where T:ILogicCtrlBehaviour
        {
            if (s_LogicBehaviourDic.TryGetValue(typeof(T).Name,out var logicCtrl))
            {
                return (T)logicCtrl;
            }
            MyLog.Warning($"Get Logic {typeof(T).Name} Fail!");
            return default(T);
        }
        
        /// <summary>
        /// 获取数据管理器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetDataMgr<T>() where T:IDataMgrBehaviour
        {
            if (s_DataBehaviourDic.TryGetValue(typeof(T).Name,out var dataMgr))
            {
                return (T)dataMgr;
            }
            MyLog.Warning($"Get Data {typeof(T).Name} Fail!");
            return default(T);
        }
        
        
        /// <summary>
        /// 获取数据管理器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetMsgMgr<T>() where T:IMsgMgrBehaviour
        {
            if (s_MsgBehaviourDic.TryGetValue(typeof(T).Name,out var msgMgr))
            {
                return (T)msgMgr;
            }
            MyLog.Error($"Get Msg {typeof(T).Name} Fail!");
            return default(T);
        }
        
        /*/// <summary>
        /// 获取执行顺序 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetBehaviourExecutionOrder<T>() where T:IBehaviourExecutionOrder,new()
        {
            return new T();
        }*/
        
    }
}