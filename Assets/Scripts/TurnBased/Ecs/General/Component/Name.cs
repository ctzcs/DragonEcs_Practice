using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/General/")]
    [Serializable]
    public struct Name:IEcsComponent
    {
        public string name;
    }

    [Serializable]
    class NameTemplate : ComponentTemplate<Name>
    {
    }
}