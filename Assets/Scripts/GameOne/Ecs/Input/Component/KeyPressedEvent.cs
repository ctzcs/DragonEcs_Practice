using DCFApixels.DragonECS;
using UnityEngine;

namespace GameOne.Ecs.Input
{
    public struct KeyPressedEvent:IEcsComponent
    {
        public KeyCode key;
    }
}