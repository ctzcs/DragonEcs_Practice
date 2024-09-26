using System;
using DCFApixels.DragonECS;

namespace Survivor.Player
{
    [MetaGroup("Survivor/Player")]
    [Serializable]
    public struct PlayerTag:IEcsTagComponent
    {
        
    }
    
    public class PlayerTagTemplate:TagComponentTemplate<PlayerTag> {}
}