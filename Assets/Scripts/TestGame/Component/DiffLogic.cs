using System;
using DCFApixels.DragonECS;

namespace Component
{
    [Serializable]
    public struct DiffLogic:IEcsComponent
    {
        public string logic;
    }
}