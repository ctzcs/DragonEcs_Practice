using UnityEngine;

namespace Framework.UI
{
    public interface IPanelView
    {
        GameObject GameObject { get; }
        
        CanvasGroup CanvasGroup { get; }
        bool Visible { get; set; }
        void OnShow();
        void OnHide();
    }
}