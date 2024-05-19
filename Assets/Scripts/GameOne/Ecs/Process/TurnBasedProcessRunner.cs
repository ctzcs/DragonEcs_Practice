using DCFApixels.DragonECS;
using DCFApixels.DragonECS.RunnersCore;

namespace GameOne.Ecs.Process
{
    public interface ITurnBasedProcess:IEcsProcess
    {
        /// <summary>
        /// 回合制管线
        /// </summary>
        void RunTurn();
    }
    
    /// <summary>
    /// 回合制的管线
    /// </summary>
    public sealed class TurnBasedProcessRunner:EcsRunner<ITurnBasedProcess>,ITurnBasedProcess
    {
        
        #region Public

        #region 接口

        public void RunTurn()
        {
            foreach (var item in Process)
            { 
                item.RunTurn();
            }
        }
        
        #endregion


        #endregion

        


        
    }
}