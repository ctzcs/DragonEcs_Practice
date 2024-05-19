
namespace GameOne
{
    public class GameStateService
    {
        public EGameState state;
        public ETurn turn;
    }


    public enum EGameState
    {
        Init,
        Play,
        Saving,
        Loading,
    }
    
    public enum ETurn
    {
        None,
        RoundStart,
        Terrain,
        EnemyAI,
        WaitForPlayerInput,
        PlayerAction,
        EnemyAction,
        RoundEnd,
        
    }
}