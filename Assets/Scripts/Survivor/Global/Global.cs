using System;
using DCFApixels.DragonECS;

namespace Survivor.Global
{
    [MetaGroup("Survivor/Global")]
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