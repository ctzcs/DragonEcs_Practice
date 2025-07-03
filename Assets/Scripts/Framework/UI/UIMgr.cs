using System.Collections.Generic;
using System.IO;
using SimpleTurnBased;
using UnityEngine;

namespace Framework.UI
{
    public class UIMgr : AutoMonoSingleton<UIMgr>
    {
        private GameObject _root;
        public GameObject Root
        {
            get
            {
                if (_root == null)
                {
                    _root = GameObject.Find("Canvas");
                }

                return _root;
            }
        }
        private Dictionary<string, IPanelView> _panelDic = new();
        private string _uiPrefabPath;
        

        private void OnDestroy()
        {
            Clear();
        }


        public void Clear()
        {
            _root = null;
            _panelDic.Clear();
        }

        public bool TryGet<T>(string panelName,out T panel) where T:BasePanelView
        {
            if (_panelDic.TryGetValue(panelName,out var p))
            {
                panel = p as T;
                return true;
            }
            panel = default;
            return false;
        }

        public IPanelView Show(string panelName)//唤起对话
        {
            if (!_panelDic.TryGetValue(panelName,out var panel))
            {
                if (string.IsNullOrEmpty(_uiPrefabPath))
                {
                    _uiPrefabPath = Path.Combine(CstStr.Prefab,CstStr.UIPath);
                }
                GameObject instance = ResMgr.Instance.Load<GameObject>( Path.Combine(_uiPrefabPath,panelName));
                if (instance == null)
                {
                    MyLog.Error($"没有找到{panelName}的预制体，无法显示");
                    return null;   
                }
                var component = instance.GetComponent<BasePanelView>();
                if (!_panelDic.TryAdd(panelName,component))
                {
                    MyLog.Error($"已经有{panelName}的预制体");
                    return null;
                }
                
                panel = component;
                
                var trans = panel.GameObject.transform as RectTransform;
                if (trans != null)
                {
                    trans.SetParent(Root.transform);
                    trans.localPosition = Vector3.zero;
                    trans.localScale = Vector3.one;
                    trans.offsetMax = Vector2.zero;
                    trans.offsetMin = Vector2.zero;
                }
            }

            panel.Visible = true;
            panel.CanvasGroup.interactable = true;
            panel.CanvasGroup.blocksRaycasts = true;
            //设置成最新的
            panel.GameObject.transform.SetAsLastSibling();
            panel.OnShow();
            return panel;
        }

        public void Hide(string panelName)
        {
            if (_panelDic.TryGetValue(panelName,out var panel))
            {
                
                panel.Visible = false;
                panel.CanvasGroup.interactable = false;
                panel.CanvasGroup.blocksRaycasts = false;
                panel.OnHide();
                return;
            }
            MyLog.Log($"没有找到{panelName}的注册，可能没有Show过");
        }


        public void Destroy(string panelName)
        {
            if (_panelDic.TryGetValue(panelName,out var panel))
            {
                //不一定需要hide
                //panel.OnHide();
                Destroy(panel.GameObject);
                _panelDic.Remove(panelName);
                return;
            }
            MyLog.Log($"没有找到{panelName}的注册，无法隐藏");
        }
    }

    
}