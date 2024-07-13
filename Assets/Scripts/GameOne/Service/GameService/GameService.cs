namespace GameOne.Service
{
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
        public IGameMode NowMode;

        public IGameMode SetMode(EGameMode mode)
        {
            switch (mode)
            {
                case EGameMode.LevelMode:
                    GameMode = mode;
                    NowMode = new LevelMode().Reset();
                    break;
            }

            return NowMode;
        }
    }

    

    
    
   
}