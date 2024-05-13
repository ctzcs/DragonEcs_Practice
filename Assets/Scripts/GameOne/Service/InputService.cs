using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameOne
{
    public class InputService
    {
        
        public class KeyInfo
        {
            public KeyCode keyCode;
            public EKeyState state;
            public bool wasPressedThisFrame;
            public bool wasReleaseThisFrame;

            public event Action<KeyCode> onPressed;
            public event Action<KeyCode> onReleased;
            
            public void PressedThisFrame()
            {
                wasPressedThisFrame = true;
                wasReleaseThisFrame = false;
                state = EKeyState.Pressed;
                onPressed?.Invoke(keyCode);
            }

            public void ReleasedThisFrame()
            {
                wasReleaseThisFrame = true;
                wasPressedThisFrame = false;
                state = EKeyState.Release;
                onReleased?.Invoke(keyCode);
            }
        }
        public enum EKeyState
        {
            Pressed,
            Release
        }
        private Dictionary<KeyCode, KeyInfo> _keyStateDic = new();
        
        public void RegisterKey(KeyCode key)
        {
            _keyStateDic.TryAdd(key,new KeyInfo()
            {
                keyCode = key,
                state = EKeyState.Release,
                wasPressedThisFrame = false,
                wasReleaseThisFrame = false,
            });
        }
        
        public void PressKey(KeyCode key)
        {
            if (!_keyStateDic.TryGetValue(key, out KeyInfo value))
            {
                throw new NullReferenceException($"haven't register {key},use RegisterKey first");
            }

            value.PressedThisFrame();

        }

        public void ReleaseKey(KeyCode key)
        {
            if (!_keyStateDic.TryGetValue(key, out KeyInfo value))
            {
                throw new NullReferenceException($"haven't register {key},use RegisterKey first");
            }
            value.ReleasedThisFrame();
        }
        

        KeyInfo GetKey(KeyCode key)
        {
            if (!_keyStateDic.TryGetValue(key,out KeyInfo value))
            {
                throw new NullReferenceException($"haven't register {key},use RegisterKey first");
            }
            return value;
        }

        
        public bool WasPressedThisFrame(KeyCode key)
        {
            return GetKey(key).wasPressedThisFrame;
        }

        public bool WasReleaseThisFrame(KeyCode key)
        {
            return GetKey(key).wasReleaseThisFrame;
        }

        public bool WasPressed(KeyCode key)
        {
            return GetKey(key).state == EKeyState.Pressed;
        }


        public void Init()
        {
            RegisterKey(KeyCode.A);
            RegisterKey(KeyCode.B);
            RegisterKey(KeyCode.C);
            RegisterKey(KeyCode.D);
            RegisterKey(KeyCode.E);
            RegisterKey(KeyCode.S);
        }
        
        

        public void Update()
        {
            foreach (var key in _keyStateDic.Keys)
            {
                KeyInfo info = GetKey(key);
                if (Input.GetKeyDown(key))
                {   
                    PressKey(key);
                }
                else if (Input.GetKeyUp(key))
                {
                    ReleaseKey(key);
                    
                }else if (WasPressedThisFrame(key))
                {
                    info.wasPressedThisFrame = false;
                    
                }else if (WasReleaseThisFrame(key))
                {
                    info.wasReleaseThisFrame = false;
                }
            }
            
        }
    }
}