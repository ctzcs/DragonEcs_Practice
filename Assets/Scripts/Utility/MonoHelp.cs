
using Unity.VisualScripting;
using UnityEngine;

using Utility.Gizmos;

namespace Utility
{
    public class MonoHelp
    {
        private static GameObject _root = new GameObject("MonoHelper");
        private static GizmosManager _gizmosManager;

        public static void Init()
        {
            _gizmosManager = New("Gizmos").AddComponent<GizmosManager>();
            _gizmosManager.Init();
        }
        public static void DrawBox(Vector3 center, Vector2 size, Color color)
        {
            _gizmosManager.AddCommand(_gizmosManager.Get<DrawBoxGizmos>().Set(center,size,color));
            
        }

        private static GameObject New(string name)
        {
            var go = new GameObject(name);
            go.transform.SetParent(_root.transform);
            return go;
        }
    }
}