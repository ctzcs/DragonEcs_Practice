using System;
using System.Collections.Generic;
using System.Reflection;

namespace Framework
{
    public class TypeMgr
    {
        /// <summary>
        /// 初始化世界程序集
        /// </summary>
        /// <param name="world"></param>
        public static void InitializedWorldAssemblies(World world)
        {
            //获取world的程序集
            Type worldType = world.GetType();
            Assembly worldAssembly = worldType.Assembly;
            
            //获取命名空间下的所有脚本，如果是框架脚本，维护创建和销毁
            string worldNamespace = worldType.Namespace;
            //执行顺序
            /*Type orderType = typeof(IBehaviourExecutionOrder);*/
            Type logicType = typeof(ILogicCtrlBehaviour);
            Type dataType = typeof(IDataMgrBehaviour);
            Type msgType = typeof(IMsgMgrBehaviour);
            
            //获取程序集中的所有继承执行顺序的类型
            var types = worldAssembly.GetTypes();
            IBehaviourExecutionOrder behaviourExecutionOrder = null;
            foreach (var type in types)
            {
                if (type.GetInterface(nameof(IBehaviourExecutionOrder)) != null)
                {
                    behaviourExecutionOrder = Activator.CreateInstance(type) as IBehaviourExecutionOrder;
                }
            }

            if (behaviourExecutionOrder is null)
            {
                MyLog.Error($"No class is inheritance from IBehaviourExecutionOder in {worldNamespace}");
            }

            List<TypeOrder> msgOrderList = new();
            List<TypeOrder> dataOrderList = new();
            List<TypeOrder> logicOrderList = new();
            foreach (var type in types)
            {
                if (type.Namespace != worldNamespace||type.IsAbstract)
                {
                    continue;
                }
                //type是不是继承这个接口,如果是的话就获得他的顺序
                if (logicType.IsAssignableFrom(type))
                {
                    int order = GetLogicBehaviourOderIndex(behaviourExecutionOrder, type);
                    TypeOrder typeOrder = new TypeOrder(order, type);
                    logicOrderList.Add(typeOrder);
                }else if (dataType.IsAssignableFrom(type))
                {
                    int order = GetDataBehaviourOderIndex(behaviourExecutionOrder, type);
                    TypeOrder typeOrder = new TypeOrder(order, type);
                    dataOrderList.Add(typeOrder);
                }else if (msgType.IsAssignableFrom(type))
                {
                    int order = GetMsgBehaviourOderIndex(behaviourExecutionOrder, type);
                    TypeOrder typeOrder = new TypeOrder(order, type);
                    msgOrderList.Add(typeOrder);
                }
            }
            //升序
            msgOrderList.Sort((a,b)=>a.order.CompareTo(b.order));
            dataOrderList.Sort((a,b)=>a.order.CompareTo(b.order));
            logicOrderList.Sort((a,b)=>a.order.CompareTo(b.order));
            //初始化脚本
            for (int i = 0; i < msgOrderList.Count; i++)
            {
                IMsgMgrBehaviour msgMgrBehaviour =(IMsgMgrBehaviour) Activator.CreateInstance(msgOrderList[i].type);
                world.AddMsgMgr(msgMgrBehaviour);
            }
            for (int i = 0; i < dataOrderList.Count; i++)
            {
                IDataMgrBehaviour dataMgrBehaviour =(IDataMgrBehaviour) Activator.CreateInstance(dataOrderList[i].type);
                world.AddDataMgr(dataMgrBehaviour);
            }
            for (int i = 0; i < logicOrderList.Count; i++)
            {
                ILogicCtrlBehaviour logicCtrlBehaviour =(ILogicCtrlBehaviour) Activator.CreateInstance(logicOrderList[i].type);
                world.AddLogicCtrl(logicCtrlBehaviour);
            }
            msgOrderList.Clear();
            dataOrderList.Clear();
            logicOrderList.Clear();
        }

        /// <summary>
        /// 获取逻辑行为脚本的执行顺序
        /// </summary>
        /// <param name="order"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static int GetLogicBehaviourOderIndex(IBehaviourExecutionOrder order,Type type)
        {
            var types = order.GetLogicBehaviourExecutionOrder();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i] == type)
                {
                    return i;
                }
            }
            return 9999;
        }
        
        /// <summary>
        /// 获取数据行为的顺序
        /// </summary>
        /// <param name="order"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static int GetDataBehaviourOderIndex(IBehaviourExecutionOrder order,Type type)
        {
            var types = order.GetDataBehaviourExecutionOrder();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i] == type)
                {
                    return i;
                }
            }
            return 9999;
        }
        
        /// <summary>
        /// 或许消息行为的顺序
        /// </summary>
        /// <param name="order"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static int GetMsgBehaviourOderIndex(IBehaviourExecutionOrder order,Type type)
        {
            var types = order.GetMsgBehaviourExecutionOrder();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i] == type)
                {
                    return i;
                }
            }
            return 9999;
        }
    }
}