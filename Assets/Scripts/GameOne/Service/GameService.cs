
namespace GameOne
{
    public abstract class GameMode { }
    public enum EGameMode
    {
        LevelMode = 0,
    }
    public enum EGameState
    {
        Init = 0,
        Play = 1,
        Saving = 2,
        Loading = 3,
    }
    public class GameService
    {
        public EGameState State;
        public EGameMode GameMode;
        public GameMode NowMode;
    }

    public class LevelMode : GameMode
    {
        public ETurn Turn;
        public enum ETurn
        {
            None = 0,
            RoundStart = 1,
            Terrain = 2,
            EnemyAI = 3,
            WaitForPlayerInput = 4,
            PlayerAction = 5,
            EnemyAction = 6,
            RoundEnd = 7,
        
        }
    }

    
    
   
}