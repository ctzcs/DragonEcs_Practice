using UnityEngine;

namespace Framework
{
    /// <summary>
    /// 逻辑层对象基类
    /// </summary>
    public abstract class LogicBehaviour:ILogicBehaviour
    {
        public Vector3 LogicPosition { get; set; }
        /// <summary>
        /// 创建
        /// </summary>
        public virtual void OnCreate(){}
        /// <summary>
        /// 销毁
        /// </summary>
        public virtual void OnDestroy(){}
        /// <summary>
        /// 帧更新
        /// </summary>
        public virtual void OnFixedUpdate(float fixedUpdateTime){}
        
        public virtual void OnSave(){}

        public virtual void OnLoad(object data){}
    }
}
