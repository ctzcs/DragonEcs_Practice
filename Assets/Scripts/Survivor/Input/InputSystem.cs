using DCFApixels.DragonECS;
using UnityEngine;

namespace Survivor.Input
{
    public class InputSystem:IEcsInit,IEcsRun
    {
        [EcsInject] private EcsDefaultWorld _world;

        #region Logic
        private UnityKeyCodeAdapter _unityInput = new UnityKeyCodeAdapter();
        #endregion
        
        public void Init()
        {
            _world.Get<InputData>().enableInput = true;
        }
        
        public void Run()
        {
            ref InputData inputData = ref _world.Get<InputData>();
            inputData.mousePosition = UnityEngine.Input.mousePosition;
            CheckKey(ref inputData,EKeyCode.W);
            CheckKey(ref inputData,EKeyCode.A);
            CheckKey(ref inputData,EKeyCode.S);
            CheckKey(ref inputData,EKeyCode.D);
        }
        
        void CheckKey(ref InputData inputData,EKeyCode keyCode)
        {
            if (_unityInput.IsKeyDown(keyCode))
            {
                inputData.Press(keyCode);
            }else if (_unityInput.IsKeyUp(keyCode))
            {
                inputData.Release(keyCode);
            }
            else if(_unityInput.IsKey(keyCode))
            {
                inputData.Pressing(keyCode);
            }
            else
            {
                inputData.BackToNormal(keyCode);
            }
            
        }
        
    }



    public interface IEKeyCodeAdapter
    {
        public bool IsKeyDown(EKeyCode keyCode);
        public bool IsKeyUp(EKeyCode keyCode);
        public bool IsKey(EKeyCode keyCode);
    }

    public class UnityKeyCodeAdapter : IEKeyCodeAdapter
    {
        public bool IsKeyDown(EKeyCode keyCode)
        {
            return UnityEngine.Input.GetKeyDown(EKeyCodeConvertToUnityKeyCode(keyCode));
        }

        public bool IsKeyUp(EKeyCode keyCode)
        {
            return UnityEngine.Input.GetKeyUp(EKeyCodeConvertToUnityKeyCode(keyCode));
        }

        public bool IsKey(EKeyCode keyCode)
        {
            return UnityEngine.Input.GetKey(EKeyCodeConvertToUnityKeyCode(keyCode));
        }
        
        KeyCode EKeyCodeConvertToUnityKeyCode(EKeyCode keyCode)
        {
            return keyCode switch
            {
                EKeyCode.A => KeyCode.A,
                EKeyCode.D => KeyCode.D,
                EKeyCode.S => KeyCode.S,
                EKeyCode.W => KeyCode.W,
                _=>KeyCode.None,
            };
        }
    }
}