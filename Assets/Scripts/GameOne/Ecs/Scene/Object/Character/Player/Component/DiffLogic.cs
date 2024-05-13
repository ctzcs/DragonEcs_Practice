using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [Serializable]
    public struct DiffLogic:IEcsComponent
    {
        public string logic;
    }
}