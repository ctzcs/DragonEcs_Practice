using DCFApixels.DragonECS;
using UnityEngine;

namespace GameOne.Ecs.Input
{
    public class InputSystem:IEcsInit,IEcsRun
    {
        [EcsInject]private EcsDefaultWorld _world;
        [EcsInject] private EcsEventWorld _eventWorld;
        
        public void Init()
        {
            EcsDebug.Print("InputSystem==>Init");
            ref var input = ref _world.Get<WorldInput>();
            input.CheckList.Add(KeyCode.A);
            input.CheckList.Add(KeyCode.B);
            input.CheckList.Add(KeyCode.S);
            input.CheckList.Add(KeyCode.E);
            input.CheckList.Add(KeyCode.Space);
        }
        
        public void Run()
        {
            ref var input = ref _world.Get<WorldInput>();
            input.mousePosition = UnityEngine.Input.mousePosition;
            input.mousePosition.z = 0;
            if (Camera.main != null) input.mouseWorldPosition = Camera.main.ScreenToWorldPoint(input.mousePosition);
            foreach (var keyCode in input.CheckList)
            {
                CheckKey(keyCode);
            }
        }
        
        void CheckKey(KeyCode key)
        {
            if (UnityEngine.Input.GetKeyUp(key))
            {
                var e = _eventWorld.NewEntity();
                ref KeyReleaseEvent  keyPressedEvent = ref _eventWorld.GetPool<KeyReleaseEvent>().Add(e);
                keyPressedEvent.key = key;
                
            }
            else if (UnityEngine.Input.GetKeyDown(key))
            {
                var e = _eventWorld.NewEntity();
                ref KeyPressedEvent  keyPressedEvent = ref _eventWorld.GetPool<KeyPressedEvent>().Add(e);
                keyPressedEvent.key = key;
            }
        }


        
    }
}