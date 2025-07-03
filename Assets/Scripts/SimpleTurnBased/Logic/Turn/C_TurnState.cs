using DCFApixels.DragonECS;

namespace SimpleTurnBased.Logic.Turn
{
    public struct C_TurnState:IEcsComponent
    {
        public EWhoOperator turn;

        public EWhoOperator nextTurn;
        
    }
    
    public enum EWhoOperator
    {
        None,
        Start,
        Player,
        AI,
        End
    }
    
    
    
    
}