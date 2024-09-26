using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/BuffModule/")]
    [MetaDescription("Buff标签，用于存放Buff Id")]
    [System.Serializable]
    public struct Buff:IEcsComponent
    {
        public string id;
    }
    
    [System.Serializable]
    class BuffTemplate:ComponentTemplate<Buff>{}
}
