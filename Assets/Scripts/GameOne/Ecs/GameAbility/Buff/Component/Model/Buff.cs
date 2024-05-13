using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/BuffModule/")]
    [System.Serializable]
    public struct Buff:IEcsComponent
    {
        public string id;
        /// <summary>
        /// buff的效果
        /// </summary>
        public string onload;
        /// <summary>
        /// 移除的时候的效果
        /// </summary>
        public string onRemove;
    }
    
    [System.Serializable]
    class BuffTemplate:ComponentTemplate<Buff>{}
}
