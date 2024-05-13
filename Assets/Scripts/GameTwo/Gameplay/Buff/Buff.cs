using DCFApixels.DragonECS;

namespace GameTwo
{
    [System.Serializable]
    public struct Buff:IEcsComponent
    {
        /// <summary>
        /// 持续的回合数
        /// </summary>
        public int lastRound;
        
        /// <summary>
        /// buff的效果
        /// </summary>
        public string onload;

        public string onRemove;
    }
    
    
    
}
