using System;
using DCFApixels.DragonECS;

namespace SimpleTurnBased.Logic.AI
{
    [MetaGroup("SimpleTurnBased/AI/")]
    [MetaDescription("AI实体")]
    [Serializable]
    public struct C_AI:IEcsComponent
    {
        public string aiName;
    }
    
    [Serializable]
    class C_AITemplate:ComponentTemplate<C_AI>
    {
        
    }
    
    
}