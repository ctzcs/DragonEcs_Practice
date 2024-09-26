using System;
using DCFApixels.DragonECS;

namespace Survivor.Player
{
    [MetaGroup("Survivor/Player")]
    [Serializable]
    public struct PlayerControlActor:IEcsComponent
    {
        /// <summary>
        /// 控制角色的索引
        /// </summary>
        public int index;
    }
    
    public class PlayerControlActorTemplate:ComponentTemplate<PlayerControlActor>{}
}