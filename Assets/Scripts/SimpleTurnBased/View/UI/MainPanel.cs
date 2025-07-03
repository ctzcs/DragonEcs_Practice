
using Framework.UI;
using SimpleTurnBased.Logic.Map;
using UnityEngine.UI;

namespace SimpleTurnBased.View.UI
{
    public class MainPanel:BasePanelView
    {
        public Button enter;

        protected override void Awake()
        {
            base.Awake();
            enter.onClick.AddListener(OnEnterClick);
        }
        

        private void OnDestroy()
        {
            enter.onClick.RemoveListener(OnEnterClick);
        }


        public override void OnShow()
        {
            base.OnShow();
            gameObject.SetActive(true);
        }

        public override void OnHide()
        {
            base.OnHide();
            gameObject.SetActive(false);
        }

        void OnEnterClick()
        {
            MapExt.EmitGenMap(ECSMgr.GetEventWorld(),"1");
            UIHelper.Hide<MainPanel>();
        }
    }
}