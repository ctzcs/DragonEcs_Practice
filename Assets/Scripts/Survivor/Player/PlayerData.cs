using System;
using DCFApixels.DragonECS;

namespace Survivor.Player
{
    [MetaGroup("Survivor/Player")]
    [Serializable]
    public struct PlayerData:IEcsComponent
    {
        public int exp;
        public int money;
    }
    
    [Serializable]
    public class PlayerDataTemplate:ComponentTemplate<PlayerData>{}
    
    
}