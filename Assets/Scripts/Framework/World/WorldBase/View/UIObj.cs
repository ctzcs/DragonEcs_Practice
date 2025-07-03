using Sirenix.OdinInspector;

namespace Framework
{
    public abstract class UIObj:RenderBehaviour
    {
        #region 框架的生命周期
        /// <summary>
        /// 是否可视
        /// </summary>
        [ShowInInspector]
        public bool IsVisible { get; private set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        [ShowInInspector]
        public bool IsAvailable { get; private set; }
        /// <summary>
        /// 显示的时候的回调
        /// </summary>
        protected virtual void OnShow()
        {
            IsAvailable = true;
        }
        
        /// <summary>
        /// 隐藏的回调
        /// </summary>
        protected virtual void OnHide()
        {
            IsAvailable = false;
        }

        public virtual void SetVisible(bool isVisible)
        {
            IsVisible = isVisible;
            if(isVisible) OnShow(); else OnHide(); 
        }

        public virtual void SetAvailable(bool isAvailable)
        {
            IsAvailable = isAvailable;
        }
        #endregion
    }
}