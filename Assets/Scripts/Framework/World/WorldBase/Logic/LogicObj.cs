namespace Framework
{
    public abstract class LogicObj:LogicBehaviour
    {
        /// <summary>
        /// 渲染对象
        /// </summary>
        public RenderObj RenderObj { get; private set; }

        /// <summary>
        /// 对象是否可用
        /// </summary>
        public bool IsAvailable { get; set; }

        public virtual void SetRenderObj(RenderObj renderObj)
        {
            IsAvailable = true;
            RenderObj = renderObj;
            LogicPosition = renderObj.CacheTransform.position;
        }
        
        public override void OnDestroy()
        {
            base.OnDestroy();
            if (RenderObj is not null)
            {
                RenderObj.OnRelease();
            }
            
        }
    }
}