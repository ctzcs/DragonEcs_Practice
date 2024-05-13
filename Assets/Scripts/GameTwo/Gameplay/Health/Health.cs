
using DCFApixels.DragonECS;

namespace GameTwo
{
    [MetaGroup("GameTwo/HealthModule/")]
    [System.Serializable]
    public struct Health:IEcsComponent
    {
        public int value;
    }
    
    [System.Serializable]
    class HealthTemplate:ComponentTemplate<Health>{}
}


