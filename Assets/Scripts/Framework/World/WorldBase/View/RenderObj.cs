using Sirenix.OdinInspector;

namespace Framework
{
    public abstract class RenderObj:RenderBehaviour
    {
        [ShowInInspector]
        public LogicObj LogicObj { get; private set; }
        public virtual void SetLogicObj(LogicObj obj)
        {
            LogicObj = obj;
        }

        public virtual void OnCreate(){ }
        /// <summary>
        /// 释放对象
        /// </summary>
        public virtual void OnRelease(){}

    }
}