using System;
using System.Collections.Generic;
using DCFApixels.DragonECS;

namespace Survivor.Property
{
    [MetaGroup("Survivor/Property")]
    [Serializable]
    public struct StateTagContainer:IEcsComponent
    {
        public Dictionary<EStateTag, StateTag> dic;

        public StateTagContainer(Dictionary<EStateTag, StateTag> dic)
        {
            this.dic = dic;
        }
    }

    public class StateTag
    {
        public EStateTag type;
        public int stack;
    }

    public enum EStateTag
    {
        
    }
    
    
    
}