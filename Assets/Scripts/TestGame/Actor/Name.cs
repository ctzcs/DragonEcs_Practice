using System;
using DCFApixels.DragonECS;

namespace Component
{
    [Serializable]
    public struct Name:IEcsComponent
    {
        public string name;
    }
}