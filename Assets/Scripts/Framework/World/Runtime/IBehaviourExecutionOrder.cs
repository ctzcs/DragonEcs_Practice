using System;

namespace Framework
{
    public interface IBehaviourExecutionOrder
    {
        Type[] GetLogicBehaviourExecutionOrder();
        Type[] GetDataBehaviourExecutionOrder();
        Type[] GetMsgBehaviourExecutionOrder();
    }
}