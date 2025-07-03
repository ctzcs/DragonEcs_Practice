using MoreMountains.Feedbacks;
using UnityEngine;

namespace Framework.UI
{
    public abstract class BasePanelView : MonoBehaviour,IPanelView
    {
        private CanvasGroup _canvasGroup;
        public GameObject GameObject => this?.gameObject;

        public CanvasGroup CanvasGroup
        {
            get
            {
                if (_canvasGroup != null) return _canvasGroup;
                if (TryGetComponent(out CanvasGroup canvasGroup))
                {
                    _canvasGroup = canvasGroup;
                }
                else
                {
                    _canvasGroup = gameObject.AddComponent<CanvasGroup>();
                }
                return _canvasGroup;
            }
        }
        public bool Visible { get; set; }
        

        [SerializeField] protected MMF_Player show;
        [SerializeField] protected MMF_Player hide;

        protected virtual void Awake()
        {
            if (show == null)
            {
                show = transform.Find("FBs/[FBs]Show")?.GetComponent<MMF_Player>();
            }
            if (hide == null)
            {
                hide = transform.Find("FBs/[FBs]Hide")?.GetComponent<MMF_Player>();
            }
            show?.Initialization();
            hide?.Initialization();
        }

        public virtual void OnShow()
        {
            hide?.StopFeedbacks();
            show?.PlayFeedbacks();
            
        }

        public virtual void OnHide()
        {
            show?.StopFeedbacks();
            hide?.PlayFeedbacks();
        }
    }
}