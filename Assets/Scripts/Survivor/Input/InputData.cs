using System.Collections.Generic;
using DCFApixels.DragonECS;
using UnityEngine;

namespace Survivor.Input
{
    public struct InputData : IEcsWorldComponent<InputData>
    {
        public bool enableInput;
        public Dictionary<EKeyCode, KeyCodeRecord> inputDic;
        public Vector2 mousePosition;
        public void Init(ref InputData component, EcsWorld world)
        {
            component.inputDic = new();
            mousePosition = Vector2.zero;
        }

        public void OnDestroy(ref InputData component, EcsWorld world)
        {
            inputDic = null;
        }

        KeyCodeRecord RegisterKey(EKeyCode keyCode)
        {
            KeyCodeRecord keyCodeRecord = new KeyCodeRecord(keyCode);
            inputDic.Add(keyCode,keyCodeRecord);
            return keyCodeRecord;
        }
        
        public void Press(EKeyCode keyCode)
        {
            if (!enableInput) return;
            if (!inputDic.TryGetValue(keyCode,out KeyCodeRecord keyCodeRecord))
            {
                keyCodeRecord = RegisterKey(keyCode);
            }
            keyCodeRecord.Press();
            
        }

        public void Release(EKeyCode keyCode)
        {
            if (!enableInput) return;
            if (!inputDic.TryGetValue(keyCode,out KeyCodeRecord keyCodeRecord))
            {
                keyCodeRecord = RegisterKey(keyCode);
            }
            keyCodeRecord.Release();
        }

        public void Pressing(EKeyCode keyCode)
        {
            if (!enableInput) return;
            if (!inputDic.TryGetValue(keyCode,out KeyCodeRecord keyCodeRecord))
            {
                keyCodeRecord = RegisterKey(keyCode);
            }
            keyCodeRecord.Pressing();
        }
        
        public void BackToNormal(EKeyCode keyCode)
        {
            if (!enableInput) return;
            if (!inputDic.TryGetValue(keyCode,out KeyCodeRecord keyCodeRecord))
            {
                keyCodeRecord = RegisterKey(keyCode);
            }
            keyCodeRecord.BackToNormal();
        }


        public bool WasPressed(EKeyCode keyCode) => GetRecord(keyCode).WasPressed;
        public bool WasUp(EKeyCode keyCode) => GetRecord(keyCode).WasReleasedInThisFrame;
        public bool WasDown(EKeyCode keyCode) => GetRecord(keyCode).WasPressedInThisFrame;
        
        public readonly KeyCodeRecord GetRecord(EKeyCode keyCode)
        {
            if (inputDic.TryGetValue(keyCode, out KeyCodeRecord keyCodeRecord)) return keyCodeRecord;
            keyCodeRecord = new KeyCodeRecord(keyCode);
            inputDic.Add(keyCode,keyCodeRecord);
            return keyCodeRecord;
        }
    }
    
    public class KeyCodeRecord
    {
        private readonly EKeyCode _keyCode;
        private bool _isDirty;
        public bool WasPressed;
        public bool WasPressedInThisFrame;
        public bool WasReleasedInThisFrame;

        public KeyCodeRecord(EKeyCode keyCode)
        {
            _keyCode = keyCode;
        }
        
        public void Press()
        {
            WasPressed = true;
            WasPressedInThisFrame = true;
            WasReleasedInThisFrame = false;
            _isDirty = true;
            EcsDebug.Print($"{_keyCode}按键按下");
        }

        public void Release()
        {
            WasPressed = false;
            WasReleasedInThisFrame = false;
            WasReleasedInThisFrame = true;
            _isDirty = true;
            EcsDebug.Print($"{_keyCode}按键释放");
        }

        public void Pressing()
        {
            if (!WasPressedInThisFrame) return;
            _isDirty = true;
            WasPressedInThisFrame = false;
            WasPressed = true;

        }
        
        public void BackToNormal()
        {
            if (!_isDirty) return;
            WasPressed = false;
            WasReleasedInThisFrame = false;
            WasReleasedInThisFrame = false;
            _isDirty = false;
            EcsDebug.Print($"{_keyCode}按键恢复正常");
        }
    }

    public enum EKeyCode
    {
        W,
        A,
        S,
        D,
        MouseLeft,
    }
    
}