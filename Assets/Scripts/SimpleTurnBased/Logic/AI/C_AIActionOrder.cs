using System.Collections.Generic;
using DCFApixels.DragonECS;

namespace SimpleTurnBased.Logic.AI
{
    /// <summary>
    /// Ai行动顺序
    /// </summary>
    public struct C_AIActionOrder:IEcsComponent
    {
        public Queue<int> entActionOrder;
    }
    
    //按顺序执行AI的行动，当所有的AI行动执行完毕，进入到下一个阶段
    //
}