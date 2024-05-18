using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/BuffModule/")]
    [System.Serializable]
    public struct Buff:IEcsComponent
    {
        public string id;
    }
    
    [System.Serializable]
    class BuffTemplate:ComponentTemplate<Buff>{}
}
