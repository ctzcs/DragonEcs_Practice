using System.Collections.Generic;
using DCFApixels.DragonECS;
using UnityEngine;

namespace GameOne.Ecs.Input
{
    public struct WorldInput:IEcsWorldComponent<WorldInput>
    {
        private string _name;
        private List<KeyCode> _checkList;
        public Vector3 mousePosition;
        public Vector3 mouseWorldPosition;
        public string Name => _name;
        public List<KeyCode> CheckList => _checkList;
        
        public void Init(ref WorldInput component, EcsWorld world)
        {
            component._name = "Input";
            component._checkList = new();
        }

        public void OnDestroy(ref WorldInput component, EcsWorld world)
        {
            _checkList = null;
        }
    }
}