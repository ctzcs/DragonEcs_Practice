using System;
using DCFApixels.DragonECS;

namespace Survivor.Global
{
    [MetaGroup("Survivor/GlobalData")]
    [Serializable]
    public struct GlobalData:IEcsComponent
    {
        
        /// <summary>
        /// 全局金币
        /// </summary>
        public int globalMoney;
    }
    
    public class GlobalDataTemplate:ComponentTemplate<GlobalData>{}
}