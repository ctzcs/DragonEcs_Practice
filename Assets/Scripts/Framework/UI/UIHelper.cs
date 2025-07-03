using System;
using System.Runtime.CompilerServices;
using SimpleTurnBased.View.UI;

namespace Framework.UI
{
    public static class UIHelper
    {
        public static IPanelView Show<T>() where T:BasePanelView
        {
            Type type = typeof(T);
            return Show(type.Name);
        }
        
        public static void Hide<T>() where T:BasePanelView
        {
            Type type = typeof(T);
            Hide(type.Name);
        }
        
        public static void Destroy<T>() where T:BasePanelView
        {
            Type type = typeof(T);
            Destroy(type.Name);
        }

        public static bool TryGet<T>(out T panel) where T : BasePanelView
        {
            var name = typeof(T).Name;
            return UIMgr.Instance.TryGet(name,out panel);
        }

        public static void Clear()
        {
            UIMgr.Instance.Clear();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IPanelView Show(string panelName)
        {
            return UIMgr.Instance.Show(panelName);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Hide(string panelName)
        {
            UIMgr.Instance.Hide(panelName);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Destroy(string panelName)
        {
            UIMgr.Instance.Destroy(panelName);
        }
        
    }
}