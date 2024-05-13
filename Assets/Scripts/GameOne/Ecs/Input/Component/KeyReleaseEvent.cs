using DCFApixels.DragonECS;
using UnityEngine;

namespace GameOne.Ecs.Input
{
    public struct KeyReleaseEvent:IEcsComponent
    {
        public KeyCode key;
    }
}