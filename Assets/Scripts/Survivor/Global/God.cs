using System;
using DCFApixels.DragonECS;

namespace Survivor.Global
{
    [MetaGroup("Survivor/Global")]
    [Serializable]
    public struct God:IEcsComponent
    {
        public string name;
    }

    [Serializable]
    class GodTemplate : ComponentTemplate<God>
    {
    }
}